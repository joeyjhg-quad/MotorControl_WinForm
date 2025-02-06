using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using mc2xxstd;
using static mc2xxstd.SscApi;

namespace MotorControl_WinForm
{
    public class MotorControlManager
    {
        int board_id = 0;
        int channel = 1;
        int ans;
        Axis1 axis1;
        Axis2 axis2;
        Axis3 axis3;
        public MotorControlManager()
        {
            bool load_lib_flg = true;
            load_lib_flg = LoadLibraryDll();
            if (load_lib_flg == false)
            {
                Logger.Log("Api Load fail");
                Debug.WriteLine("Api Load fail.\n");
                return;
            }
            axis1 = new Axis1();
            axis2 = new Axis2();
            axis3 = new Axis3();
        }
        public void GetCurrentPosition(int[] positions)
        {
            for (int i = 0; i < 3; i++)
            {
                ans = sscGetCurrentCmdPositionFast(board_id, channel, i + 1, out positions[i]);
                if (ans != SSC_OK)
                    positions[i] = -1;
            }
        }

        public void GetDriveFin(int[] finStatus)
        {
            for (int i = 0; i < 3; ++i)
            {
                int ans = sscGetDriveFinStatus(board_id, channel, i + 1, SSC_FIN_TYPE_SMZ, out finStatus[i]);
                if (ans != SSC_OK)
                {
                    Debug.WriteLine($"sscGetDriveFinStatus failed for axis {i + 1}. sscGetLastError=0x{sscGetLastError():X}");
                    finStatus[i] = -1;
                }
            }
        }


        public void Open()
        {
            int ans = sscOpen(board_id);
            if (ans != SSC_OK)
            {
                Debug.WriteLine($"sscOpen failure. sscGetLastError=0x{sscGetLastError():X}");
            }
            else
            {
                Logger.Log("sscOpen success");
                Debug.WriteLine("sscOpen success");
            }
        }
        public void Close()
        {
            int ans = sscClose(board_id);
            if (ans != SSC_OK)
            {
                Debug.WriteLine($"sscClose failure. sscGetLastError=0x{sscGetLastError():X}");
            }
            else
            {
                Logger.Log("sscClose success");
                Debug.WriteLine("sscClose success");
            }
        }
        public void RebootAndStart()
        {
            int ans = sscReboot(board_id, channel, SSC_DEFAULT_TIMEOUT);
            if (ans != SSC_OK)
            {
                Debug.WriteLine($"sscReboot failure. sscGetLastError=0x{sscGetLastError():X}");
                return;
            }

            ans = sscResetAllParameter(board_id, channel, SSC_DEFAULT_TIMEOUT);
            if (ans != SSC_OK)
            {
                Debug.WriteLine($"sscResetAllParameter failure. sscGetLastError=0x{sscGetLastError():X}");
                return;
            }

            ans = sscLoadAllParameterFromFlashROM(board_id, channel, SSC_DEFAULT_TIMEOUT);
            if (ans != SSC_OK)
            {
                Debug.WriteLine($"sscLoadAllParameterFromFlashROM failure. sscGetLastError=0x{sscGetLastError():X}");
                return;
            }

            ans = sscSystemStart(board_id, channel, SSC_DEFAULT_TIMEOUT);
            if (ans != SSC_OK)
            {
                Debug.WriteLine($"sscSystemStart failure. sscGetLastError=0x{sscGetLastError():X}");
                return;
            }
            Logger.Log("RebootAndStart success");

        }

        public void SetPoint(PNT_DATA_EX pntData)
        {
            axis1.SetPoint(pntData);
            axis2.SetPoint(pntData);
            axis3.SetPoint(pntData);
        }

        public void ServoOn(int axisNum)
        {
            switch (axisNum)
            {
                case 1:
                    axis1.ServoOn();
                    break;
                case 2:
                    axis2.ServoOn();
                    break;
                case 3:
                    axis3.ServoOn();
                    break;
            }
        }

        public void ServoOff(int axisNum)
        {
            switch (axisNum)
            {
                case 1:
                    axis1.ServoOff();
                    break;
                case 2:
                    axis2.ServoOff();
                    break;
                case 3:
                    axis3.ServoOff();
                    break;
            }
        }

        public void JogMove(int axisNum, int direction)
        {
            switch (axisNum)
            {
                case 1:
                    if (direction == 1) axis1.JogMoveMinus();
                    else if (direction == 0) axis1.JogMovePlus();
                    break;
                case 2:
                    if (direction == 1) axis2.JogMoveMinus();
                    else if (direction == 0) axis2.JogMovePlus();
                    break;
                case 3:
                    if (direction == 1) axis3.JogMoveMinus();
                    else if (direction == 0) axis3.JogMovePlus();
                    break;
            }
        }

        public void JogStop(int axisNum)
        {
            switch (axisNum)
            {
                case 1:
                    axis1.JogStop();
                    break;
                case 2:
                    axis2.JogStop();
                    break;
                case 3:
                    axis3.JogStop();
                    break;
            }
        }

        public void CustomMove(int axisNum, int distance)
        {
            switch (axisNum)
            {
                case 1:
                    axis1.CustomMove(distance);
                    break;
                case 2:
                    axis2.CustomMove(distance);
                    break;
                case 3:
                    axis3.CustomMove(distance);
                    break;
            }
        }

        public void PositionMove(int[] input)
        {
            int[] positions = new int[3];
            for (int i = 0; i < 3; i++)
            {
                int ans = sscGetCurrentCmdPositionFast(board_id, channel, i + 1, out positions[i]);
                if (ans != SSC_OK) positions[i] = -1;

                int position = input[i];
                int moveDistance = position - positions[i];

                switch (i)
                {
                    case 0:
                        axis1.CustomMove(moveDistance);
                        break;
                    case 1:
                        axis2.CustomMove(moveDistance);
                        break;
                    case 2:
                        axis3.CustomMove(moveDistance);
                        break;
                }
            }
        }
        public void EmergencyStop()
        {
            for (int i = 0; i < 3; i++)
            {
                ans = sscDriveStop(board_id, channel, i + 1, 0);
                if (ans != SSC_OK)
                {
                    Debug.WriteLine($"sscDriveStop failure. sscGetLastError=0x{sscGetLastError():X}");
                }
                else
                {
                    Logger.Log($"axis{i + 1} sscDriveStop success");
                    Debug.WriteLine($"axis{i + 1} sscDriveStop success");
                }
            }
        }
        public void Sequence1(int pos1, int pos2, int pos3, int pos4)
        {
            Logger.Log("Sequence1 start");

            int[] positionsArray = { pos1, pos2, pos3, pos4 };
            int count = 0;
            int currentPosition = 0;
            int moveDistance = 0;

            for (int i = 4; i > 0; i--)
            {
                // 순서 : 3축+ 2축 1축 3축-
                int axisNumber = (i + 1) % 3 + 1;

                // 현재 명령 위치 가져오기
                ans = sscGetCurrentCmdPositionFast(board_id, channel, axisNumber, out currentPosition);
                if (ans != SSC_OK)
                {
                    Debug.WriteLine($"sscGetCurrentCmdPositionFast failed for axis {axisNumber}. sscGetLastError=0x{sscGetLastError():X}\n");
                    return;
                }

                moveDistance = positionsArray[count] - currentPosition;
                CustomMove(axisNumber, moveDistance);
                count++;

                // n초 동안 sscGetDriveFinStatus로 상태 확인
                const int TIMEOUT_SEC = 10; // 최대 대기 시간 (초)
                const int CHECK_INTERVAL_MS = 100; // 상태 확인 간격 (밀리초)

                for (int elapsedTime = 0; elapsedTime < TIMEOUT_SEC * 1000; elapsedTime += CHECK_INTERVAL_MS)
                {
                    int finStatus = 0;
                    ans = sscGetDriveFinStatus(board_id, channel, axisNumber, SSC_FIN_TYPE_SMZ, out finStatus);

                    if (ans != SSC_OK)
                    {
                        Debug.WriteLine($"sscGetDriveFinStatus failed for axis {axisNumber}. sscGetLastError=0x{sscGetLastError():X}\n");
                        return; // 에러 발생 시 종료
                    }

                    // 운전 완료 상태 확인
                    if (finStatus == SSC_FIN_STS_STP) // 운전 완료 상태
                    {
                        Debug.WriteLine($"Axis {axisNumber}: Drive finished successfully.\n");
                        break;
                    }
                    else if (finStatus == SSC_FIN_STS_ALM_STP || finStatus == SSC_FIN_STS_ALM_MOV) // 알람 상태
                    {
                        Debug.WriteLine($"Axis {axisNumber}: Alarm detected. Status={finStatus}\n");
                        switch (axisNumber)
                        {
                            case 1:
                                axis1.CheckAlarm();
                                break;
                            case 2:
                                axis2.CheckAlarm();
                                break;
                            case 3:
                                axis3.CheckAlarm();
                                break;
                            default:
                                break;
                        }
                        return; // 알람 발생 시 종료
                    }

                    // 상태 확인 간격 대기
                    Thread.Sleep(CHECK_INTERVAL_MS);
                }
            }
            Logger.Log("Sequence1 end");
        }
        public void Sequence2(int pos1, int pos2, int pos3, int pos4)
        {
            Logger.Log("Sequence2 start");
            int[] positionsArray = { pos1, pos2, pos3, pos4 };
            int count = 0;
            int currentPosition = 0;
            int moveDistance = 0;

            for (int i = 0; i < 4; i++)
            {
                // 순서 : 3축+ 1축 2축 3축-
                int axisNumber = (i + 2) % 3 + 1;

                // 현재 명령 위치 가져오기
                ans = sscGetCurrentCmdPositionFast(board_id, channel, axisNumber, out currentPosition);
                if (ans != SSC_OK)
                {
                    Debug.WriteLine($"sscGetCurrentCmdPositionFast failed for axis {axisNumber}. sscGetLastError=0x{sscGetLastError():X}\n");
                    return;
                }

                moveDistance = positionsArray[count] - currentPosition;
                CustomMove(axisNumber, moveDistance);
                count++;

                // n초 동안 sscGetDriveFinStatus로 상태 확인
                const int TIMEOUT_SEC = 10; // 최대 대기 시간 (초)
                const int CHECK_INTERVAL_MS = 100; // 상태 확인 간격 (밀리초)

                for (int elapsedTime = 0; elapsedTime < TIMEOUT_SEC * 1000; elapsedTime += CHECK_INTERVAL_MS)
                {
                    int finStatus = 0;
                    ans = sscGetDriveFinStatus(board_id, channel, axisNumber, SSC_FIN_TYPE_SMZ, out finStatus);

                    if (ans != SSC_OK)
                    {
                        Debug.WriteLine($"sscGetDriveFinStatus failed for axis {axisNumber}. sscGetLastError=0x{sscGetLastError():X}\n");
                        return; // 에러 발생 시 종료
                    }

                    // 운전 완료 상태 확인
                    if (finStatus == SSC_FIN_STS_STP) // 운전 완료 상태
                    {
                        Debug.WriteLine($"Axis {axisNumber}: Drive finished successfully.\n");
                        break;
                    }
                    else if (finStatus == SSC_FIN_STS_ALM_STP || finStatus == SSC_FIN_STS_ALM_MOV) // 알람 상태
                    {
                        Debug.WriteLine($"Axis {axisNumber}: Alarm detected. Status={finStatus}\n");
                        switch (axisNumber)
                        {
                            case 1:
                                axis1.CheckAlarm();
                                break;
                            case 2:
                                axis2.CheckAlarm();
                                break;
                            case 3:
                                axis3.CheckAlarm();
                                break;
                            default:
                                break;
                        }
                        return; // 알람 발생 시 종료
                    }

                    // 상태 확인 간격 대기
                    Thread.Sleep(CHECK_INTERVAL_MS);
                }
            }
            Logger.Log("Sequence2 end");
        }

        public void HomeReturn()
        {
            Logger.Log("HomeReturn start");
            // 3축 -> 1축 -> 2축 순서대로 원점 복귀
            for (int i = 0; i < 3; i++)
            {
                int axisNumber = (i + 2) % 3 + 1; // 3축 -> 1축 -> 2축 순서 계산
                ans = sscHomeReturnStart(board_id, channel, axisNumber);

                if (ans != SSC_OK)
                {
                    Debug.WriteLine($"HomeReturn failure for axis {axisNumber}. sscGetLastError=0x{sscGetLastError():X}\n");
                    return;
                }
                else
                {
                    Debug.WriteLine($"HomeReturn started successfully for axis {axisNumber}\n");
                }

                // 상태 확인: n초 동안 sscGetDriveFinStatus로 상태 확인
                const int TIMEOUT_SEC = 30; // 최대 대기 시간 (초)
                const int CHECK_INTERVAL_MS = 100; // 상태 확인 간격 (밀리초)
                bool isCompleted = false;

                for (int elapsedTime = 0; elapsedTime < TIMEOUT_SEC * 1000; elapsedTime += CHECK_INTERVAL_MS)
                {
                    int fin_status = 0;
                    ans = sscGetDriveFinStatus(board_id, channel, axisNumber, SSC_FIN_TYPE_SMZ, out fin_status);

                    if (ans != SSC_OK)
                    {
                        Debug.WriteLine($"sscGetDriveFinStatus failed for axis {axisNumber}. sscGetLastError=0x{sscGetLastError():X}\n");
                        return; // 에러 발생 시 복귀 종료
                    }

                    // 운전 완료 상태 확인
                    if (fin_status == SSC_FIN_STS_STP) // 운전 완료 상태
                    {
                        Debug.WriteLine($"Axis {axisNumber}: Drive finished successfully.\n");
                        isCompleted = true;
                        break;
                    }
                    else if (fin_status == SSC_FIN_STS_ALM_STP || fin_status == SSC_FIN_STS_ALM_MOV) // 알람 상태
                    {
                        Debug.WriteLine($"Axis {axisNumber}: Alarm detected. Status={fin_status}\n");
                        switch (axisNumber)
                        {
                            case 1:
                                axis1.CheckAlarm();
                                break;
                            case 2:
                                axis2.CheckAlarm();
                                break;
                            case 3:
                                axis3.CheckAlarm();
                                break;
                            default:
                                break;
                        }
                        return; // 알람 발생 시 복귀 종료
                    }

                    // 상태 확인 간격 대기
                    Thread.Sleep(CHECK_INTERVAL_MS);
                }

                if (!isCompleted)
                {
                    Debug.WriteLine($"Timeout while waiting for axis {axisNumber} to complete drive.\n");
                    return; // 타임아웃 시 복귀 종료
                }
            }

            Logger.Log("HomeReturn end");
            Debug.WriteLine("Home return process completed for all axes.\n");
        }

    }
}