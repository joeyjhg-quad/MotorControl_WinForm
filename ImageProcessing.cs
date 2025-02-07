using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace MotorControl_WinForm
{
    public class ImageProcessing
    {
        private Mat img;
        private List<OpenCvSharp.Point> detectedCenters;
        private OpenCvSharp.Point[] SelectedPoint;
        List<List<OpenCvSharp.Point>> rows;
        private MotorControlManager motorControlManager;
        double offset = Constants.offset;
        int arrSize = Constants.size;
        int emptyCount = Constants.emptyCount;
        public event Action<Mat> OnProcessingCompleted;

        public ImageProcessing()
        {

        }

        public void Init(Mat inputImg, MotorControlManager motorManager)
        {
            img = inputImg.Clone();
            motorControlManager = motorManager;
            detectedCenters = new List<OpenCvSharp.Point>();
            rows = new List<List<OpenCvSharp.Point>>();
            offset = Constants.offset;
            arrSize = Constants.size;
            emptyCount = Constants.emptyCount;
        }

        public void Start()
        {
            if (img == null)
            {
                throw new Exception("이미지가 아직 로드되지 않았습니다.");
            }
            try
            {
                Logger.Log("ImageProcessing Start");
                ProcessImage();
                FindContoursAndCenters();
                SortCentersIntoGrid();
                //ProcessGrid();
                ProcessGrid_MasterImg();
                ShowContours();
                //NumberAndMove();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void ProcessImage()
        {
            Mat gray = new Mat();
            Mat binary = new Mat();
            Cv2.CvtColor(img, gray, ColorConversionCodes.BGR2GRAY);
            Cv2.AdaptiveThreshold(
                gray,
                binary,
                255,
                AdaptiveThresholdTypes.MeanC,
                ThresholdTypes.Binary,
                91, // 홀수여야 함
                17
            );
            img = binary;
        }

        private void FindContoursAndCenters()
        {
            OpenCvSharp.Point[][] contours;
            HierarchyIndex[] hierarchy;
            Cv2.FindContours(img, out contours, out hierarchy, RetrievalModes.Tree, ContourApproximationModes.ApproxSimple);
            detectedCenters.Clear();

            //test
            //Mat contourImg = img.Clone();
            //Cv2.CvtColor(contourImg, contourImg, ColorConversionCodes.GRAY2BGR);
            //Cv2.DrawContours(contourImg, contours, -1, Scalar.Red, 2); // 모든 컨투어를 빨간색으로 그림
            //Cv2.Resize(contourImg, contourImg, new OpenCvSharp.Size(600, 600));
            //Cv2.ImShow("Detected Contours", contourImg);
            //Cv2.WaitKey(0); // 1ms 동안 대기 (UI 멈추는 것 방지)

            foreach (OpenCvSharp.Point[] contour in contours)
            {
                double area = Cv2.ContourArea(contour);
                double round = Cv2.ArcLength(contour, true);
                if (area > Constants.AREA_LOW && area < Constants.AREA_HIGH && round > Constants.ROUND_LOW && round < Constants.ROUND_HIGH)
                {
                    Moments M = Cv2.Moments(contour);
                    int x = (int)(M.M10 / M.M00);
                    int y = (int)(M.M01 / M.M00);
                    detectedCenters.Add(new OpenCvSharp.Point(x, y));
                }
            }
        }
        private void SortCentersIntoGrid()
        {
            if (detectedCenters.Count == 0) return;

            // 1. Y 값 기준 정렬 (맨 위의 점 찾기)
            detectedCenters.Sort((p1, p2) => p1.Y.CompareTo(p2.Y));
            rows = new List<List<OpenCvSharp.Point>>();

            // 2. y값이 가장 큰 점을 기준점으로 선택
            OpenCvSharp.Point Y_max = detectedCenters[0];

            // 3. 기준점에서 가장 가까운 두 점 찾기
            OpenCvSharp.Point close1 = new OpenCvSharp.Point();
            OpenCvSharp.Point close2 = new OpenCvSharp.Point();
            double dis_close1 = double.MaxValue;
            double dis_close2 = double.MaxValue;

            foreach (OpenCvSharp.Point p in detectedCenters)
            {
                if (p == Y_max) continue; // 본인 제외

                double currentDistance = Math.Sqrt(Math.Pow(p.X - Y_max.X, 2) + Math.Pow(p.Y - Y_max.Y, 2));

                if (currentDistance < dis_close1)
                {
                    close2 = close1;
                    dis_close2 = dis_close1;

                    close1 = p;
                    dis_close1 = currentDistance;
                }
                else if (currentDistance < dis_close2)
                {
                    close2 = p;
                    dis_close2 = currentDistance;
                }
            }

            // 4. 두 점 중 Y값이 더 가까운 점을 선택하여 기울기 계산
            double m;
            if (Math.Abs(Y_max.Y - close1.Y) < Math.Abs(Y_max.Y - close2.Y))
                m = (Y_max.X != close1.X) ? (double)(Y_max.Y - close1.Y) / (Y_max.X - close1.X) : 0;
            else
                m = (Y_max.X != close2.X) ? (double)(Y_max.Y - close2.Y) / (Y_max.X - close2.X) : 0;

            // 5. 기울기 기반 행 분류
            double Threshold = 0.05;

            while (detectedCenters.Count > 0)
            {
                List<OpenCvSharp.Point> currentRow = new List<OpenCvSharp.Point>();
                List<OpenCvSharp.Point> toRemove = new List<OpenCvSharp.Point>();

                foreach (OpenCvSharp.Point p in detectedCenters)
                {
                    if (Y_max == p)
                    {
                        currentRow.Add(p);
                        toRemove.Add(p);
                        continue;
                    }

                    double p_m = (double)(Y_max.Y - p.Y) / (Y_max.X - p.X);
                    if (p_m > m - Threshold && p_m < m + Threshold)
                    {
                        currentRow.Add(p);
                        toRemove.Add(p);
                    }
                }

                // 사용한 점 제거
                foreach (var p in toRemove)
                    detectedCenters.Remove(p);

                // 다음 기준점 설정
                if (detectedCenters.Count > 0)
                    Y_max = detectedCenters[0];

                // X 좌표 기준 정렬 후 추가
                currentRow.Sort((p1, p2) => p1.X.CompareTo(p2.X));
                rows.Add(currentRow);
            }
        }
        private void ProcessGrid()
        {
            // 기준점 3개 찾기
            Point p1 = rows[0][0]; // 1행 1번째
            Point p2 = rows[0][4]; // 1행 5번째
            Point p3 = rows[10][0]; // 11행 1번째
            Point p4 = rows[10][4]; // 11행 5번째

            // 기울기 계산
            double m1 = GetSlope(rows[0][0], rows[0][4]);
            double m2 = GetSlope(rows[10][0], rows[10][4]);
            double m3 = GetSlope(rows[0][0], rows[10][0]);
            double m3_rotated = (m3 == 0) ? double.PositiveInfinity : (m3 == double.PositiveInfinity ? 0 : -1 / m3);

            // 기울기 평균값 계산
            double avgSlope = (m1 + m2 + m3_rotated) / 3;
            bool isReverse = avgSlope > 0;
            double colSlope = (avgSlope == 0) ? double.PositiveInfinity : -1 / avgSlope;

            // 좌상단 시작점 계산
            Point topLeft = MovePoint(p1, avgSlope, -(offset * emptyCount), isReverse);

            List<List<Point>> fullGrid = new List<List<Point>>();

            // 행 단위로 이동 (y 방향)
            for (int i = 0; i < arrSize; i++)
            {
                List<Point> row = new List<Point>();

                // 첫 번째 열의 기준이 되는 시작점 설정
                Point rowStartPoint = MovePoint(topLeft, colSlope, offset * i, isReverse);

                // 열 단위로 이동 (x 방향)
                for (int j = 0; j < arrSize; j++)
                {
                    Point newPoint = MovePoint(rowStartPoint, avgSlope, offset * j, isReverse);
                    row.Add(newPoint);
                }

                fullGrid.Add(row);
            }

            // 불필요한 포인트 제거
            int[] colRemovals = new int[arrSize];
            for (int i = 0; i < arrSize; i++)
            {
                int distFromEdge = Math.Min(i, arrSize - 1 - i);
                colRemovals[i] = Math.Max(emptyCount - distFromEdge, 0);
            }
            List<List<Point>> filteredGrid = new List<List<Point>>();

            for (int i = 0; i < arrSize; i++)
            {
                int removeCount = colRemovals[i];
                List<Point> row = fullGrid[i].Skip(removeCount).Take(arrSize - removeCount * 2).ToList();
                filteredGrid.Add(row);
            }

            rows.Clear();
            rows = filteredGrid;
        }
        private void ProcessGrid_MasterImg()
        {
            // 기준점 3개 찾기
            Point p1 = rows[0][0]; // 1행 1번째
            Point p2 = rows[0][4]; // 1행 5번째
            Point p3 = rows[rows.Count - 1][0]; // 11행 1번째
            Point p4 = rows[rows.Count - 1][4]; // 11행 5번째

            // 기울기 계산
            double m1 = GetSlope(p1, p2);
            double m2 = GetSlope(p3, p4);
            double m3 = GetSlope(p1, p3);
            double m3_rotated = (m3 == 0) ? double.PositiveInfinity : (m3 == double.PositiveInfinity ? 0 : -1 / m3);

            // 기울기 평균값 계산
            double avgSlope = (m1 + m2 + m3_rotated) / 3;

            // 중앙점 계산
            Point mid = new Point();
            mid.X = (p1.X + p4.X) / 2;
            mid.Y = (p1.Y + p4.Y) / 2;

            List<List<Point>> fullGrid = CreateMasterImg(mid,avgSlope,offset);

            // 불필요한 포인트 제거
            int[] colRemovals = new int[arrSize];
            for (int i = 0; i < arrSize; i++)
            {
                int distFromEdge = Math.Min(i, arrSize - 1 - i);
                colRemovals[i] = Math.Max(emptyCount - distFromEdge, 0);
            }

            // 결과 확인
            //Console.WriteLine(string.Join(", ", colRemovals));

            List<List<Point>> filteredGrid = new List<List<Point>>();

            for (int i = 0; i < arrSize; i++)
            {
                int removeCount = colRemovals[i];
                List<Point> row = fullGrid[i].Skip(removeCount).Take(arrSize - removeCount * 2).ToList();
                filteredGrid.Add(row);
            }

            rows.Clear();
            rows = filteredGrid;
        }


        private void ShowContours()
        {
            Mat resultImg = img.Clone();
            Cv2.CvtColor(resultImg, resultImg, ColorConversionCodes.GRAY2BGR);

            HashSet<(int, int)> visited = new HashSet<(int, int)>();

            int center1 = rows.Count / 2;
            int SelectedX = center1;
            int SelectedY = center1;

            // x 좌표 보정 배열 생성
            int emptyCount = (rows.Count - rows[0].Count) / 2;
            int[] xCorrCoeff = new int[rows.Count];

            for (int i = 0; i < xCorrCoeff.Length; i++)
            {
                if (i < emptyCount)
                {
                    xCorrCoeff[i] = i - emptyCount;
                }
                else if (i >= xCorrCoeff.Length - emptyCount)
                {
                    xCorrCoeff[i] = xCorrCoeff.Length - 1 - i - emptyCount;
                }
            }

            // 시작점 선택 및 보정
            int xCorrValue = SelectedX + xCorrCoeff[SelectedY];
            Point point = rows[SelectedY][xCorrValue];
            visited.Add((xCorrValue, SelectedY));

            // 왼쪽, 위쪽, 오른쪽, 아래쪽 방향
            int[] dx = { -1, 0, 1, 0 };
            int[] dy = { 0, -1, 0, 1 };

            int d = 0;
            int total = rows.Sum(row => row.Count);
            int repeats = 1;
            int checkRepeat = 0;

            SelectedPoint = new Point[total];

            // 시작점 추가
            int counter = 0;
            SelectedPoint[counter] = point;
            Cv2.Circle(resultImg, point, 10, Scalar.Blue, -1);
            Cv2.PutText(resultImg, (counter + 1).ToString(),
                        new Point(point.X + 10, point.Y),
                        HersheyFonts.HersheySimplex, 2.5, Scalar.Red, 3);
            counter++;

            while (visited.Count < total)
            {
                for (int repeat = 0; repeat < repeats; repeat++)
                {
                    // 이동
                    SelectedX += dx[d];
                    SelectedY += dy[d];

                    // 보정된 x 좌표 적용
                    if (SelectedY < 0 || SelectedY >= rows.Count)
                        continue;

                    xCorrValue = SelectedX + xCorrCoeff[SelectedY];

                    // 범위 체크
                    if (xCorrValue < 0 || xCorrValue >= rows[SelectedY].Count)
                        continue;
                    if (visited.Contains((xCorrValue, SelectedY)))
                        continue;

                    // 현재 선택된 점
                    point = rows[SelectedY][xCorrValue];

                    // 점 저장 후 카운터 증가
                    SelectedPoint[counter] = point;
                    counter++;

                    // 점 그리기
                    Cv2.Circle(resultImg, point, 10, Scalar.Blue, -1);

                    // 숫자 표시
                    Cv2.PutText(resultImg, counter.ToString(),
                                new Point(point.X + 10, point.Y),
                                HersheyFonts.HersheySimplex, 2.5, Scalar.Red, 3);

                    visited.Add((xCorrValue, SelectedY));

                    if (visited.Count >= total) break;
                }

                if (visited.Count >= total) break;

                checkRepeat++;
                d = (d + 1) % 4; // 방향 변경 (왼쪽 → 위 → 오른쪽 → 아래)
                if (checkRepeat % 2 == 0) repeats++; // 반복 횟수 증가
            }

            // 결과 이미지 표시
            //Cv2.Resize(resultImg, resultImg, new OpenCvSharp.Size(800, 800));
            //Cv2.ImShow("Contours", resultImg);
            //Cv2.WaitKey(0);
            //Cv2.DestroyAllWindows();
            OnProcessingCompleted?.Invoke(resultImg.Clone());
        }





        public void NumberAndMove()
        {
            Logger.Log("Move Start");
            double pixelToUm = 4.928;
            OpenCvSharp.Point currentPosition = new OpenCvSharp.Point(img.Width / 2, img.Height / 2);
            OpenCvSharp.Point targetPosition;

            for (int i = 0; i < SelectedPoint.Length; i++)
            {
                targetPosition = SelectedPoint[i];
                int deltaX = targetPosition.X - currentPosition.X;
                int deltaY = targetPosition.Y - currentPosition.Y;
                int moveX = (int)(deltaX * pixelToUm);
                int moveY = (int)(deltaY * pixelToUm);
                motorControlManager.CustomMove(2, moveX);
                motorControlManager.CustomMove(1, moveY);
                currentPosition = targetPosition;
                Thread.Sleep(1000);
            }
        }
        public double GetSlope(Point a, Point b)
        {
            int dx = b.X - a.X;
            int dy = b.Y - a.Y;
            return dx == 0 ? double.PositiveInfinity : (double)dy / dx;
        }
        private List<List<Point>> CreateMasterImg(Point mid, double m, double offset)
        {
            List<List<Point>> grid = new List<List<Point>>();

            // 정사각형을 만들기 위한 기준 좌표 (top-left 찾기)
            Point topLeft = new Point(mid.X - (int)(offset * 5), mid.Y - (int)(offset * 5));

            // 1. 기울기 없이 정사각형 격자 생성
            for (int i = 0; i < arrSize; i++)
            {
                List<Point> row = new List<Point>();

                for (int j = 0; j < arrSize; j++)
                {
                    int x = topLeft.X + (int)(offset * j);
                    int y = topLeft.Y + (int)(offset * i);
                    row.Add(new Point(x, y));
                }

                grid.Add(row);
            }

            // 2. 기울기 적용 (각 점을 m만큼 회전 변환)
            List<List<Point>> rotatedGrid = new List<List<Point>>();
            foreach (var row in grid)
            {
                List<Point> rotatedRow = new List<Point>();
                foreach (var p in row)
                {
                    rotatedRow.Add(RotatePoint(mid, p, m));
                }
                rotatedGrid.Add(rotatedRow);
            }

            return rotatedGrid;
        }
        private Point RotatePoint(Point center, Point p, double m)
        {
            // 기울기를 회전각으로 변환
            double angle = Math.Atan(m); // 기울기에 대한 각도 (라디안)

            // 회전 변환 공식 적용
            double cosA = Math.Cos(angle);
            double sinA = Math.Sin(angle);

            int x = p.X - center.X;
            int y = p.Y - center.Y;

            int newX = (int)Math.Round(x * cosA - y * sinA) + center.X;
            int newY = (int)Math.Round(x * sinA + y * cosA) + center.Y;

            return new Point(newX, newY);
        }
        public Point MovePoint(Point p1, double m_avg, double x_offset, bool isReverse)
        {
            if (double.IsInfinity(m_avg))
            {
                // 수직 이동 (m_avg가 무한대일 경우)
                return new Point(p1.X, p1.Y + (int)Math.Round(x_offset));
            }

            // 이동 벡터 크기 (정규화 필요)
            double length = Math.Sqrt(1 + m_avg * m_avg);

            // 정규화된 이동 벡터
            int dx = (int)Math.Round(x_offset / length);
            int dy = (int)Math.Round(x_offset * m_avg / length);
            if (isReverse && m_avg < 0) 
            {
                dx = -dx;
                dy = -dy;
            }
            // 새로운 좌표 계산
            return new Point(p1.X + dx, p1.Y + dy);
        }
        public void SaveMatImage(string filePath, string format = "png")
        {
            if (img == null || img.Empty())
            {
                Console.WriteLine("Error: 이미지가 비어 있습니다.");
                return;
            }

            // 지원되는 확장자 확인
            string extension = format.ToLower();
            if (extension != "jpg" && extension != "jpeg" && extension != "png" && extension != "bmp")
            {
                Console.WriteLine("Error: 지원되지 않는 파일 형식입니다. (jpg, png, bmp 가능)");
                return;
            }

            // 파일 경로가 올바른지 확인
            if (string.IsNullOrEmpty(filePath) || !Directory.Exists(filePath))
            {
                MessageBox.Show("Error: 지정된 경로가 올바르지 않습니다.");
                return;
            }

            // 파일명 지정 (기본값: "image")
            string fileNameWithoutExtension = "image";

            // 현재 시간 추가하여 새로운 파일 경로 생성
            string timeStamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string newFilePath = Path.Combine(filePath, $"{fileNameWithoutExtension}_{timeStamp}.{extension}");

            // 동일한 파일이 존재하는지 체크
            if (File.Exists(newFilePath))
            {
                Console.WriteLine("Error: 동일한 파일이 이미 존재합니다. 저장하지 않았습니다.");
                return;
            }

            try
            {
                // 파일 저장
                bool result = Cv2.ImWrite(newFilePath, img);

                if (result)
                    Console.WriteLine($"이미지가 {newFilePath} 파일로 저장되었습니다.");
                else
                    Console.WriteLine("Error: 이미지 저장 실패");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: 저장 중 예외 발생 - {ex.Message}");
            }
        }


    }

}
