using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using mc2xxstd;
using static mc2xxstd.SscApi;
using Basler.Pylon;
using System.Drawing.Imaging;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using OpenCvSharp.XImgProc;

namespace MotorControl_WinForm
{
    public partial class Form1 : Form
    {
        MotorControlManager motorControlManager = new MotorControlManager();
        ThreadManager threadManager = new ThreadManager();
        CameraManager cameraManager = new CameraManager();
        TextFileManager textFileManager = new TextFileManager();
        PNT_DATA_EX PntData;
        Mat img = null;
        private System.Windows.Forms.Timer positionUpdateTimer;
        bool isExpanded = false;
        int currentY = 10;
        //Camera  camera;
        public Form1()
        {
            InitializeComponent();
            Logger.Initialize(this);
            this.Load += (sender, e) =>
            {
                //this.WindowState = FormWindowState.Maximized;
                //this.FormBorderStyle = FormBorderStyle.None; // 테두리 없애기
                this.StartPosition = FormStartPosition.Manual;
                this.Location = new System.Drawing.Point(0, 0); // 화면의 (0, 0) 위치로 설정
            };
            SetAllValues(textFileManager.GetAllValues());
            UpdatePanel();
            motorControlManager.Open();
            motorControlManager.RebootAndStart();
            motorControlManager.ServoOn(1);
            motorControlManager.ServoOn(2);
            motorControlManager.ServoOn(3);

            PntData.position = 0;

            PntData.dwell = 0;                              /* 0ms							*/
            PntData.subcmd = SSC_SUBCMD_POS_ABS             /* Absolute Position			*/
                | SSC_SUBCMD_STOP_SMZ;                      /* Smoothing Stop				*/
            PntData.s_curve = 100;                          /* 100% 						*/
            motorControlManager.SetPoint(PntData);
            Update_Speed();
            positionUpdateTimer = new System.Windows.Forms.Timer();
            positionUpdateTimer.Interval = 50; // 50ms마다 위치 갱신
            positionUpdateTimer.Tick += PositionUpdate_Tick;
            positionUpdateTimer.Start();
            //HomeReturn();
            cameraManager.OnImageUpdated += (mat, count) =>
            {
                // UI 업데이트는 Invoke를 사용해야 함
                Invoke(new Action(() =>
                {
                    // 기존 Mat 객체 삭제 (메모리 누수 방지)
                    img?.Dispose();

                    // Mat으로 변환하여 img에 저장
                    img = mat.Clone();

                    // 원본 이미지 크기 구하기
                    int width = mat.Width;
                    int height = mat.Height;

                    // 중심 좌표 계산
                    int centerX = width / 2;
                    int centerY = height / 2;

                    // 기존 이미지 삭제
                    pictureBox1.Image?.Dispose();

                    Mat displayMat;

                    if (isExpanded)
                    {
                        // tb_Expanded의 값 가져오기 (예: 200% -> 2배 확대)
                        if (int.TryParse(tb_Expanded.Text, out int expandPercent))
                        {
                            double scaleFactor = expandPercent / 100.0; // 확대 비율
                            int cropWidth = (int)(width / scaleFactor);
                            int cropHeight = (int)(height / scaleFactor);

                            // 확대할 영역 계산 (중앙 확대)
                            int cropX = Math.Max(0, centerX - cropWidth / 2);
                            int cropY = Math.Max(0, centerY - cropHeight / 2);
                            cropWidth = Math.Min(cropWidth, width - cropX);
                            cropHeight = Math.Min(cropHeight, height - cropY);

                            // ROI(Region of Interest) 설정 후 잘라내기
                            Mat croppedMat = new Mat(mat, new OpenCvSharp.Rect(cropX, cropY, cropWidth, cropHeight));

                            // PictureBox 크기에 맞춰 확대
                            displayMat = new Mat();
                            Cv2.Resize(croppedMat, displayMat, new OpenCvSharp.Size(width, height), 0, 0, InterpolationFlags.Linear);

                            // 메모리 해제
                            croppedMat.Dispose();
                        }
                        else
                        {
                            displayMat = mat.Clone(); // 변환 실패 시 원본 유지
                        }
                    }
                    else
                    {
                        // 원본 그대로 사용
                        displayMat = mat.Clone();
                    }

                    // 확대된 이미지에 빨간색 십자가 그리기 (수직선은 확대된 후에 그림)
                    Scalar redColor = new Scalar(0, 0, 255); // BGR 순서로 빨간색
                    int thickness = 10; // 선 두께

                    // 새 중심 좌표 계산
                    int newCenterX = displayMat.Width / 2;
                    int newCenterY = displayMat.Height / 2;

                    // 가로선
                    Cv2.Line(displayMat, new OpenCvSharp.Point(0, newCenterY), new OpenCvSharp.Point(displayMat.Width, newCenterY), redColor, thickness);

                    // 세로선 (확대 후에 그림)
                    Cv2.Line(displayMat, new OpenCvSharp.Point(newCenterX, 0), new OpenCvSharp.Point(newCenterX, displayMat.Height), redColor, thickness);

                    // Mat을 Bitmap으로 변환하여 PictureBox에 표시
                    Bitmap bitmap = BitmapConverter.ToBitmap(displayMat);
                    pictureBox1.Image = bitmap;

                    // 메모리 해제
                    displayMat.Dispose();

                    // 레이블 업데이트
                    label27.Text = count.ToString();
                }));


            };

        }
        public void SetAllValues(string[] values)
        {
            // 문자열 배열에서 값을 적절한 타입으로 변환
            PntData.speed = Convert.ToUInt32(values[ColumnIndex.SPEED]);
            PntData.actime = Convert.ToUInt16(values[ColumnIndex.ACTIME]);
            PntData.dctime = Convert.ToUInt16(values[ColumnIndex.DCTIME]);
            Constants.AREA_LOW = Convert.ToInt32(values[ColumnIndex.AREA_LOW]);
            Constants.AREA_HIGH = Convert.ToInt32(values[ColumnIndex.AREA_HIGH]);
            Constants.ROUND_LOW = Convert.ToInt32(values[ColumnIndex.ROUND_LOW]);
            Constants.ROUND_HIGH = Convert.ToInt32(values[ColumnIndex.ROUND_HIGH]);
            Constants.offset = Convert.ToDouble(values[ColumnIndex.OFFSET]);
            Constants.size = Convert.ToInt32(values[ColumnIndex.SIZE]);
            Constants.emptyCount = Convert.ToInt32(values[ColumnIndex.EMPTYCOUNT]);
            Constants.ExposureTime = Convert.ToInt32(values[ColumnIndex.EXPOSURETIME]);
            Constants.Path = values[ColumnIndex.PATH];

            // 텍스트 박스에 값 설정
            tb_AREA_LOW.Text = Constants.AREA_LOW.ToString();
            tb_AREA_HIGH.Text = Constants.AREA_HIGH.ToString();
            tb_ROUND_LOW.Text = Constants.ROUND_LOW.ToString();
            tb_ROUND_HIGH.Text = Constants.ROUND_HIGH.ToString();
            tb_Offset.Text = Constants.offset.ToString();
            tb_SizeOfArr.Text = Constants.size.ToString();
            tb_EmptyCount.Text = Constants.emptyCount.ToString();
            tb_ExposureTime.Text = Constants.ExposureTime.ToString();
            tb_Path.Text = Constants.Path.ToString();
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            threadManager.Stop();
            motorControlManager.ServoOff(1);
            motorControlManager.ServoOff(2);
            motorControlManager.ServoOff(3);
            motorControlManager.Close();
        }
        private void PositionUpdate_Tick(object sender, EventArgs e)
        {
            int[] positions = new int[3];
            motorControlManager.GetCurrentPosition(positions);

            // UI 스레드에서 실행하도록 Invoke 사용
            if (tb_Position_X.InvokeRequired)
            {
                tb_Position_X.Invoke(new Action(() =>
                {
                    tb_Position_X.Text = positions[0].ToString();
                    tb_Position_Y.Text = positions[1].ToString();
                    tb_Position_Z.Text = positions[2].ToString();
                }));
            }
            else
            {
                tb_Position_X.Text = positions[0].ToString();
                tb_Position_Y.Text = positions[1].ToString();
                tb_Position_Z.Text = positions[2].ToString();
            }
        }

        private void Update_Speed()
        {
            tb_Speed_Now.Text = PntData.speed.ToString();
            tb_Tca_Now.Text = PntData.actime.ToString();
            tb_Tcd_Now.Text = PntData.dctime.ToString();
        }
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            if (threadManager.IsWorkerRunning())
            {
                MessageBox.Show("작업 중");
                return;
            }
            threadManager.AddWorkerTask(() =>
        {
            try
            {
                motorControlManager.Open();
                motorControlManager.RebootAndStart();
                motorControlManager.SetPoint(PntData);
            }
            catch (Exception ex)
            {
                // 에러 메시지 로그 출력 또는 UI 알림
                Debug.WriteLine($"Error: {ex.Message}");
            }
        });
        }
        private void btn_Disconnect_Click(object sender, EventArgs e)
        {
            if (threadManager.IsWorkerRunning())
            {
                MessageBox.Show("작업 중");
                return;
            }
            threadManager.AddWorkerTask(() =>
            {
                try
                {
                    motorControlManager.Close();
                }
                catch (Exception ex)
                {
                    // 에러 메시지 로그 출력 또는 UI 알림
                    Debug.WriteLine($"Error: {ex.Message}");
                }
            });
        }
        private void btn_SpeedSetUp_Click(object sender, EventArgs e)
        {
            if (threadManager.IsWorkerRunning())
            {
                MessageBox.Show("작업 중");
                return;
            }
            if (uint.TryParse(tb_Speed_Target.Text, out uint speed) && ushort.TryParse(tb_Tca_Target.Text, out ushort tca) && ushort.TryParse(tb_Tcd_Target.Text, out ushort tcd))
            {
                PntData.speed = speed;
                PntData.actime = tca;
                PntData.dctime = tcd;
                threadManager.AddWorkerTask(() => motorControlManager.SetPoint(PntData));
                Invoke(new Action(() =>
                {
                    Update_Speed();
                }));
                textFileManager.SetValue(ColumnIndex.SPEED, speed.ToString());
                textFileManager.SetValue(ColumnIndex.ACTIME, tca.ToString());
                textFileManager.SetValue(ColumnIndex.DCTIME, tcd.ToString());
            }
            else
            {
                MessageBox.Show("알맞은 값 확인");
                return;
            }

            //UI스레드 사용 
        }
        private void Servo_ON_OFF(object sender, EventArgs e)
        {
            if (sender is Button button && button.Tag is string tagValue)
            {
                // 문자열 "1,0"을 ','로 분리하여 튜플로 변환
                var parts = tagValue.Split(',');
                if (parts.Length == 2 &&
                    int.TryParse(parts[0], out int axis) &&
                    int.TryParse(parts[1], out int direction))
                {
                    if (direction == 0)
                    {
                        threadManager.AddWorkerTask(() => motorControlManager.ServoOn(axis));
                    }
                    else if (direction == 1)
                    {
                        threadManager.AddWorkerTask(() => motorControlManager.ServoOff(axis));
                    }
                }
            }
        }
        private void CustomMove(object sender, EventArgs e)
        {
            if (threadManager.IsWorkerRunning())
            {
                MessageBox.Show("작업 중");
                return;
            }
            if (sender is Button button && button.Tag is string tagValue)
            {
                if (string.IsNullOrWhiteSpace(tb_CustomMove.Text))
                {
                    MessageBox.Show("값을 입력해주세요.");
                    return;
                }
                if (!int.TryParse(tb_CustomMove.Text, out int distance))
                {
                    MessageBox.Show("정수를 입력해주세요.");
                    return;
                }
                distance *= (int)(double.Parse(tb_Distance.Text) * 1000);
                // 문자열 "1,0"을 ','로 분리하여 튜플로 변환
                var parts = tagValue.Split(',');
                if (parts.Length == 2 &&
                    int.TryParse(parts[0], out int axis) &&
                    int.TryParse(parts[1], out int direction))
                {
                    if (direction == 0)
                    {
                        threadManager.AddWorkerTask(() => motorControlManager.CustomMove(axis, distance));
                    }
                    else if (direction == 1)
                    {
                        distance *= -1;
                        threadManager.AddWorkerTask(() => motorControlManager.CustomMove(axis, distance));
                    }
                }
            }
        }
        private void JogButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is Button button && button.Tag is string tagValue)
            {
                // 문자열 "1,0"을 ','로 분리하여 튜플로 변환
                var parts = tagValue.Split(',');
                if (parts.Length == 2 &&
                    int.TryParse(parts[0], out int axis) &&
                    int.TryParse(parts[1], out int direction))
                {
                    threadManager.AddWorkerTask(() => motorControlManager.JogMove(axis, direction));
                }
            }
        }
        private void JogButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (sender is Button button && button.Tag is string tagValue)
            {
                // 문자열 "1,0"을 ','로 분리하여 튜플로 변환
                var parts = tagValue.Split(',');
                if (parts.Length == 2 &&
                    int.TryParse(parts[0], out int axis))
                {
                    threadManager.AddWorkerTask(() => motorControlManager.JogStop(axis));
                }
            }
        }

        private void btn_PositionMove_Click(object sender, EventArgs e)
        {
            if (threadManager.IsWorkerRunning())
            {
                MessageBox.Show("작업 중");
                return;
            }
            if (int.TryParse(tb_PositionMove_X.Text, out int positionX) && int.TryParse(tb_PositionMove_Y.Text, out int positionY) && int.TryParse(tb_PositionMove_Z.Text, out int positionZ))
            {
                int[] position = { positionX, positionY, positionZ };
                threadManager.AddWorkerTask(() => motorControlManager.PositionMove(position));
            }
            else
            {
                MessageBox.Show("알맞은 값 확인");
                return;
            }
        }
        private void btn_DistanceSet_Click(object sender, EventArgs e)
        {
            if (sender is Button button && button.Tag is string tagValue)
            {
                tb_Distance.Text = tagValue;
            }
        }
        private void btn_EmergencyStop_Click(object sender, EventArgs e)
        {
            motorControlManager.EmergencyStop();
        }

        private void HomeReturn()
        {
            if (threadManager.IsWorkerRunning())
            {
                MessageBox.Show("작업 중");
                return;
            }
            Thread.Sleep(1000);
            threadManager.AddWorkerTask(() => motorControlManager.HomeReturn());

        }

        private void btn_Sequence1_Click(object sender, EventArgs e)
        {
            if (threadManager.IsWorkerRunning())
            {
                MessageBox.Show("작업 중");
                return;
            }
            threadManager.AddWorkerTask(() =>
            {
                int s1 = 16000;
                int s2 = 221000;
                int s3 = 150000;
                int s4 = -52000;
                motorControlManager.Sequence1(s1, s2, s3, s4);
            });

        }

        private void btn_Sequence2_Click(object sender, EventArgs e)
        {
            if (threadManager.IsWorkerRunning())
            {
                MessageBox.Show("작업 중");
                return;
            }
            threadManager.AddWorkerTask(() =>
            {
                int s1 = 16000;
                int s2 = 9000;
                int s3 = 292000;
                int s4 = -7300;
                motorControlManager.Sequence2(s1, s2, s3, s4);
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cameraManager.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cameraManager.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            // 타이머 시작
            try
            {

                Mat src = img.Clone();
                Mat gray = new Mat();
                Mat binary = new Mat();
                Mat dil_ero = new Mat();
                Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);

                Cv2.NamedWindow("binary");
                Cv2.NamedWindow("dil_ero");

                int val = 0, val2 = 0, val3 = 0;

                Cv2.CreateTrackbar("threshold", "binary", ref val, 255);
                Cv2.CreateTrackbar("dilate", "dil_ero", ref val2, 20);
                Cv2.CreateTrackbar("erode", "dil_ero", ref val3, 20);

                Mat element1 = Cv2.GetStructuringElement(MorphShapes.Rect, new OpenCvSharp.Size(3, 3));

                while (true)
                {
                    val = Cv2.GetTrackbarPos("threshold", "binary");
                    val2 = Cv2.GetTrackbarPos("dilate", "dil_ero");
                    val3 = Cv2.GetTrackbarPos("erode", "dil_ero");

                    Cv2.Threshold(gray, binary, val, 255, ThresholdTypes.Binary);
                    Cv2.ImShow("binary", binary);

                    Cv2.Dilate(binary, binary, element1, null, val2);
                    Cv2.Erode(binary, binary, element1, null, val3);

                    Cv2.ImShow("dil_ero", binary);

                    if (Cv2.WaitKey(30) == 27) // ESC 키
                        break;
                }

                //Mat Thre_clone = binary.Clone();
                //Cv2.Dilate(binary, binary, element1, null, 10);  //팽창
                //Cv2.Erode(binary, binary, element1, null, 7);   //침식
                //Cv2.Resize(binary, binary, new OpenCvSharp.Size(800, 800));
                //Cv2.ImShow("binary2", binary);


                OpenCvSharp.Point[][] contours;
                HierarchyIndex[] hierarchy;

                Cv2.FindContours(binary, out contours, out hierarchy, RetrievalModes.Tree, ContourApproximationModes.ApproxSimple);
                //log.Info("FindContours.OK");

                //Cv2.DrawContours(src, contours, -1, new Scalar(0, 0, 255), 5, LineTypes.Link8, null, 1);
                //Cv2.Resize(src, src, new OpenCvSharp.Size(800, 800));
                //Cv2.ImShow("contours", src);
                //크기 비교 - 중간 네모 찾기
                List<OpenCvSharp.Point[]> new_contours = new List<OpenCvSharp.Point[]>();
                List<OpenCvSharp.Point> center = new List<OpenCvSharp.Point>();

                List<int> list_area = new List<int>();
                List<int> list_round = new List<int>();

                foreach (OpenCvSharp.Point[] p in contours)
                {
                    double area = Cv2.ContourArea(p);
                    double round = Cv2.ArcLength(p, true);
                    if (area > Constants.AREA_LOW && area < Constants.AREA_HIGH && round > Constants.ROUND_LOW && round < Constants.ROUND_HIGH)
                    {
                        new_contours.Add(p);
                        Moments M = Cv2.Moments(p);

                        list_area.Add((int)area);
                        list_round.Add((int)round);

                        int x = (int)(M.M10 / M.M00);
                        int y = (int)(M.M01 / M.M00);
                        center.Add(new OpenCvSharp.Point(x, y));
                    }

                }
                list_area.Sort();
                list_round.Sort();
                int areaMin = list_area[0];
                int areaMax = list_area[list_area.Count - 1];
                int roundMin = list_round[0];
                int roundMax = list_round[list_round.Count - 1];



                Cv2.DrawContours(src, new_contours, -1, new Scalar(0, 0, 255), 5, LineTypes.Link8, null, 1);

                //1. 센터값 정렬
                center.Sort((p1, p2) => p1.Y.CompareTo(p2.Y));
                //2. y값이 최대인 점 식별
                OpenCvSharp.Point Y_max = center[0];
                //3. 기울기 식별
                double m = 0;
                //3-1. 가장 가까운 점 2곳 식별
                OpenCvSharp.Point close1 = new OpenCvSharp.Point();
                OpenCvSharp.Point close2 = new OpenCvSharp.Point();
                double dis_close1 = double.MaxValue; // 초기화: 최대값으로 설정
                double dis_close2 = double.MaxValue;

                foreach (OpenCvSharp.Point p in center)
                {
                    if (p == Y_max) // 본인 제외
                        continue;

                    double currentDistance = Math.Sqrt(Math.Pow(p.X - Y_max.X, 2) + Math.Pow(p.Y - Y_max.Y, 2));

                    if (currentDistance < dis_close1)
                    {
                        // 기존 close1을 close2로 밀어냄
                        close2 = close1;
                        dis_close2 = dis_close1;

                        // close1 갱신
                        close1 = p;
                        dis_close1 = currentDistance;
                    }
                    else if (currentDistance < dis_close2)
                    {
                        // close2만 갱신
                        close2 = p;
                        dis_close2 = currentDistance;
                    }
                }
                //3-2. y값이 근사한 점을 찾아, dx/dy로 기울기를 구함
                if (Math.Abs(Y_max.Y - close1.Y) < Math.Abs(Y_max.Y - close2.Y))
                    m = (double)(Y_max.Y - close1.Y) / (double)(Y_max.X - close1.X);
                else
                    m = (double)(Y_max.Y - close2.Y) / (double)(Y_max.X - close2.X);

                double Threshold = 0.07;
                //6. 4,5를 반복해 다음 점들이 없을때 까지 반복
                List<List<OpenCvSharp.Point>> rows = new List<List<OpenCvSharp.Point>>();
                while (center.Count > 0)
                {
                    List<OpenCvSharp.Point> removePoint = new List<OpenCvSharp.Point>();
                    List<OpenCvSharp.Point> currentRow = new List<OpenCvSharp.Point>();
                    foreach (OpenCvSharp.Point p in center)
                    {
                        if (Y_max == p)
                        {
                            currentRow.Add(p);
                            removePoint.Add(p);
                            continue;
                        }
                        double p_m = ((double)(Y_max.Y - p.Y) / (double)(Y_max.X - p.X));
                        if (p_m > m - Threshold && p_m < m + Threshold)
                        {
                            currentRow.Add(p);
                            removePoint.Add(p);
                        }
                    }

                    foreach (OpenCvSharp.Point p in removePoint)
                        center.Remove(p);
                    if (center.Count > 0)
                        Y_max = center[0];
                    rows.Add(currentRow);
                }
                //4. y값이 최대인 점에서 기울기에 근사한 점들을 모두 구함
                //5. 다음 좌표는, 4번의 점들을 뺀 나머지중 y값이 최대인 점으로 함.
                // 각 행을 x 좌표 기준으로 정렬
                foreach (var row in rows)
                {
                    row.Sort((p1, p2) => p1.X.CompareTo(p2.X));
                }

                // 행별로 선을 잇고 번호를 출력
                //HersheyFonts font = HersheyFonts.HersheySimplex;
                int count = 1;
                for (int i = 0; i < rows.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        for (int j = 0; j < rows[i].Count; j++)
                        {
                            // 번호 출력
                            //Cv2.PutText(src, $"{count}", rows[i][j], font, 3, new Scalar(255, 0, 0), 3);
                            Cv2.Circle(src, rows[i][j], 10, new Scalar(0, 255, 0), -1, LineTypes.AntiAlias);

                            count++;

                            // 선 그리기 (다음 점이 있는 경우에만)
                            if (j < rows[i].Count - 1)
                            {
                                Cv2.Line(src, rows[i][j], rows[i][j + 1], new Scalar(255, 0, 0), 10, LineTypes.AntiAlias);
                            }
                        }

                        // 다음 행이 있는 경우, 행 끝과 다음 행의 시작을 연결
                        if (i < rows.Count - 1)
                        {
                            Cv2.Line(src, rows[i][rows[i].Count - 1], rows[i + 1][rows[i + 1].Count - 1], new Scalar(255, 0, 0), 10, LineTypes.AntiAlias);
                        }
                    }
                    else
                    {
                        for (int j = 0; j < rows[i].Count; j++)
                        {
                            int reverse_j = rows[i].Count - j - 1;
                            // 번호 출력
                            //Cv2.PutText(src, $"{count}", rows[i][reverse_j], font, 3, new Scalar(255, 0, 0), 3);
                            Cv2.Circle(src, rows[i][reverse_j], 10, new Scalar(0, 255, 0), -1, LineTypes.AntiAlias);
                            count++;

                            // 선 그리기 (다음 점이 있는 경우에만)
                            if (j < rows[i].Count - 1)
                            {
                                Cv2.Line(src, rows[i][reverse_j], rows[i][reverse_j - 1], new Scalar(255, 0, 0), 10, LineTypes.AntiAlias);
                            }
                        }

                        // 다음 행이 있는 경우, 행 끝과 다음 행의 시작을 연결
                        if (i < rows.Count - 1)
                        {
                            Cv2.Line(src, rows[i][0], rows[i + 1][0], new Scalar(255, 0, 0), 10, LineTypes.AntiAlias);
                        }
                    }
                }
                Cv2.Resize(src, src, new OpenCvSharp.Size(800, 800));
                Cv2.ImShow("contours", src);

            }
            catch (Exception ex) { }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            ImageProcessing imgProcessor = new ImageProcessing(img, motorControlManager);
            threadManager.AddWorkerTask(() => imgProcessor.Start());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ImageProcessing imgProcessor = new ImageProcessing(img, motorControlManager);
            threadManager.AddWorkerTask(() => imgProcessor.SaveMatImage(Constants.Path));
        }

        private void btn_Constants_Change_Click(object sender, EventArgs e)
        {
            textFileManager.SetValue(ColumnIndex.AREA_LOW, tb_AREA_LOW.Text);
            textFileManager.SetValue(ColumnIndex.AREA_HIGH, tb_AREA_HIGH.Text);
            textFileManager.SetValue(ColumnIndex.ROUND_LOW, tb_ROUND_LOW.Text);
            textFileManager.SetValue(ColumnIndex.ROUND_HIGH, tb_ROUND_HIGH.Text);
            textFileManager.SetValue(ColumnIndex.OFFSET, tb_Offset.Text);
            textFileManager.SetValue(ColumnIndex.SIZE, tb_SizeOfArr.Text);
            textFileManager.SetValue(ColumnIndex.EMPTYCOUNT, tb_EmptyCount.Text);
            textFileManager.SetValue(ColumnIndex.EXPOSURETIME, tb_ExposureTime.Text);
            SetAllValues(textFileManager.GetAllValues());
            cameraManager.SetExposureTime(int.Parse(tb_ExposureTime.Text.ToString()));
            MessageBox.Show("변경 완료");
        }

        private void btn_Expanded_Click(object sender, EventArgs e)
        {
            // isExpanded 상태 토글
            isExpanded = !isExpanded;

            // 버튼의 눌린 현상 추가
            if (isExpanded)
            {
                btn_Expanded.FlatStyle = FlatStyle.Popup; // 눌린 스타일
                btn_Expanded.BackColor = SystemColors.ControlDark; // 눌린 배경색
               // btn_Expanded.Text = "접기"; // 버튼 텍스트 변경
                tb_Expanded.ReadOnly = true;
            }
            else
            {
                btn_Expanded.FlatStyle = FlatStyle.Standard; // 기본 스타일
                btn_Expanded.BackColor = SystemColors.ControlLight; // 기본 배경색
                //btn_Expanded.Text = "확장"; // 버튼 텍스트 변경
                tb_Expanded.ReadOnly = false;

            }
        }

        private void btn_Fullscreen_Click(object sender, EventArgs e)
        {
            // img를 Clone하여 새로운 Mat 생성
            Mat resizedImg = new Mat();
            Cv2.Resize(img, resizedImg, new OpenCvSharp.Size(1000, 1000), 0, 0, InterpolationFlags.Linear);

            // OpenCV 창 이름 설정
            string windowName = "Resized Image";

            // 창을 생성 (일반 창)
            Cv2.NamedWindow(windowName, WindowFlags.AutoSize);

            // 이미지 표시
            Cv2.ImShow(windowName, resizedImg);

            // ESC 키 입력 시 창 닫기
            while (true)
            {
                int key = Cv2.WaitKey(1); // 1ms 대기하면서 키 입력 감지
                if (key == 27) // ESC 키(ASCII 코드 27) 감지
                {
                    Cv2.DestroyWindow(windowName);
                    break;
                }
            }

            // 메모리 해제
            resizedImg.Dispose();
        }

        private void btn_PathSetting_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                // 폴더 선택 창 설정
                folderBrowserDialog.Description = "폴더를 선택하세요";
                folderBrowserDialog.ShowNewFolderButton = false; // 새 폴더 생성 버튼 비활성화

                // 폴더 선택 후 확인 버튼을 눌렀을 때
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    tb_Path.Text = folderBrowserDialog.SelectedPath;
                    Constants.Path = folderBrowserDialog.SelectedPath;
                    textFileManager.SetValue(ColumnIndex.PATH, tb_Path.Text);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // 텍스트박스 값 읽기
            string name = tb_SaveName.Text;
            string P_X = tb_PositionMove_X.Text;
            string P_Y = tb_PositionMove_Y.Text;
            string P_Z = tb_PositionMove_Z.Text;

            // 값이 비어있는지 확인
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(P_X) || string.IsNullOrEmpty(P_Y) || string.IsNullOrEmpty(P_Z))
            {
                MessageBox.Show("모든 입력 필드를 채워주세요.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // 값이 비어있다면 함수 종료
            }

            // 값이 비어있지 않으면 배열에 저장
            string[] val = new string[4];
            val[0] = name;
            val[1] = P_X;
            val[2] = P_Y;
            val[3] = P_Z;

            // SetValue 함수 호출
            textFileManager.SetValue(ColumnIndex.SAVEXYZ, val);

            UpdatePanel();
            //TextBox textBox = new TextBox();
            //textBox.Location = new System.Drawing.Point(100, currentY);

            //Button button = new Button();
            //button.Text = "버튼 " + currentY;
            //button.Location = new System.Drawing.Point(250, currentY);

        }
        private void UpdatePanel()
        {
            // 기존 컨트롤 초기화
            panel_SaveXYZ.Controls.Clear();

            // GetValue_XYZ()로 값을 받음
            string[][] xyzValues = textFileManager.GetValue_XYZ();

            if (xyzValues == null)
            {
                return; // 값이 없다면 아무 것도 추가하지 않음
            }

            // 각 항목에 대해 라벨과 버튼 추가
            int yOffset = 10; // 시작 위치

            for (int i = 0; i < xyzValues.Length; i++)
            {
                // XYZ 값
                string name = xyzValues[i][0];
                string pX = xyzValues[i][1];
                string pY = xyzValues[i][2];
                string pZ = xyzValues[i][3];

                // 라벨 1: Name
                Label lblName = new Label();
                lblName.Text = name;
                lblName.Location = new System.Drawing.Point(10, yOffset);
                panel_SaveXYZ.Controls.Add(lblName);

                // 라벨 2: X
                Label lblX = new Label();
                lblX.Text = pX;
                lblX.Location = new System.Drawing.Point(150, yOffset);
                panel_SaveXYZ.Controls.Add(lblX);

                // 라벨 3: Y
                Label lblY = new Label();
                lblY.Text = pY;
                lblY.Location = new System.Drawing.Point(250, yOffset);
                panel_SaveXYZ.Controls.Add(lblY);

                // 라벨 4: Z
                Label lblZ = new Label();
                lblZ.Text = pZ;
                lblZ.Location = new System.Drawing.Point(350, yOffset);
                panel_SaveXYZ.Controls.Add(lblZ);

                // 이동 버튼
                Button btnMove = new Button();
                btnMove.Text = "Move";
                btnMove.Tag = new string[] { pX, pY, pZ }; // X, Y, Z 값을 Tag에 저장
                btnMove.Location = new System.Drawing.Point(450, yOffset);
                //btnMove.Click += BtnMove_Click; // 이벤트 핸들러 연결
                panel_SaveXYZ.Controls.Add(btnMove);

                // 삭제 버튼
                Button btnDelete = new Button();
                btnDelete.Text = "Delete";
                btnDelete.Tag = name; // Name을 Tag에 저장
                btnDelete.Location = new System.Drawing.Point(550, yOffset);
                //btnDelete.Click += BtnDelete_Click; // 이벤트 핸들러 연결
                panel_SaveXYZ.Controls.Add(btnDelete);

                // Y축 위치 업데이트 (다음 항목을 아래로 배치)
                yOffset += 40; // 각 항목마다 40px씩 아래로 내려감
            }
        }
    }
    static class Constants
    {
        public static int AREA_LOW { get; set; }
        public static int AREA_HIGH { get; set; }
        public static int ROUND_LOW { get; set; }
        public static int ROUND_HIGH { get; set; }
        public static double offset { get; set; }
        public static int size { get; set; }
        public static int emptyCount { get; set; }
        public static int ExposureTime { get; set; }
        public static string Path { get; set; }
    }

}
