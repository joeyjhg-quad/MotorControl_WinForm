
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections.Concurrent;

namespace MotorControl_WinForm
{
    internal class ThreadManager
    {
        private readonly object lockObject = new object(); // 작업 관리용 Lock
        private readonly Queue<Action> uiTaskQueue = new Queue<Action>();  // UI 스레드에서 처리할 작업 큐
        private readonly Queue<Action> workerTaskQueue = new Queue<Action>();  // 작업 스레드에서 처리할 작업 큐

        private readonly Thread workerThread;  // 작업 스레드
        private readonly Thread uiThread;      // UI 스레드
        private AutoResetEvent workerTaskSignal = new AutoResetEvent(false);  // 작업 스레드 신호
        private AutoResetEvent uiTaskSignal = new AutoResetEvent(false);      // UI 스레드 신호
        private bool isRunning = true;  // 실행 여부

        public ThreadManager()
        {
            // 작업 스레드 초기화
            workerThread = new Thread(ProcessWorkerTasks)
            {
                IsBackground = true
            };
            workerThread.Start();

            // UI 스레드 초기화
            uiThread = new Thread(ProcessUITasks)
            {
                IsBackground = true
            };
            uiThread.Start();
        }

        // 작업 스레드에서 실행할 작업 처리
        private void ProcessWorkerTasks()
        {
            while (isRunning)
            {
                workerTaskSignal.WaitOne();  // 작업 스레드 신호 대기

                Action taskToExecute = null;

                lock (lockObject)
                {
                    // 작업 큐에서 작업이 있으면 가져오기
                    if (workerTaskQueue.Count > 0)
                    {
                        taskToExecute = workerTaskQueue.Peek();  // 큐에서 작업을 꺼내지만 제거하지 않음
                    }
                }

                if (taskToExecute != null)
                {
                    try
                    {
                        taskToExecute();  // 작업 실행
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"작업 스레드 작업 중 오류 발생: {ex.Message}");
                    }

                    // 작업 실행 후 큐에서 제거
                    lock (lockObject)
                    {
                        if (workerTaskQueue.Count > 0)
                        {
                            workerTaskQueue.Dequeue();  // 작업 큐에서 작업 제거
                        }
                    }
                }
            }
        }


        // UI 스레드에서 실행할 작업 처리
        private void ProcessUITasks()
        {
            while (isRunning)
            {
                uiTaskSignal.WaitOne();  // UI 스레드 신호 대기

                Action taskToExecute = null;
                lock (lockObject)
                {
                    if (uiTaskQueue.Count > 0)
                    {
                        taskToExecute = uiTaskQueue.Dequeue();  // UI 큐에서 작업 가져오기
                    }
                }

                if (taskToExecute != null)
                {
                    try
                    {
                        taskToExecute();  // UI 작업 실행
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"UI 스레드 작업 중 오류 발생: {ex.Message}");
                    }
                }
            }
        }

        // 작업 스레드에 작업 추가
        public void AddWorkerTask(Action task)
        {
            lock (lockObject)
            {
                // 작업 큐에 작업이 있으면 계속 추가하고, 작업 스레드가 대기 중일 때만 신호를 보냄
                if (workerTaskQueue.Count == 0)
                {
                    workerTaskQueue.Enqueue(task);  // 작업 큐에 작업 추가
                    workerTaskSignal.Set();  // 작업 스레드 신호 전송
                }
                else
                {
                    Console.WriteLine("작업 스레드가 이미 실행 중이어서 새 작업을 처리할 수 없습니다.");
                }
            }
        }


        // UI 스레드에 작업 추가
        public void AddUITask(Action task)
        {
            lock (lockObject)
            {
                uiTaskQueue.Enqueue(task);  // UI 작업 큐에 작업 추가
                uiTaskSignal.Set();  // UI 스레드 신호 전송
            }
        }

        // 종료 메서드
        public void Stop()
        {
            isRunning = false;
            workerTaskSignal.Set();  // 작업 스레드 종료 신호
            uiTaskSignal.Set();  // UI 스레드 종료 신호
            workerThread.Join();
            uiThread.Join();
        }

        // 작업 스레드가 실행 중인지 확인
        public bool IsWorkerRunning()
        {
            lock (lockObject)
            {
                return workerTaskQueue.Count > 0;  // 작업 스레드 큐에 작업이 있으면 실행 중
            }
        }

        // UI 스레드가 실행 중인지 확인
        public bool IsUIRunning()
        {
            lock (lockObject)
            {
                return uiTaskQueue.Count > 0;  // UI 스레드 큐에 작업이 있으면 실행 중
            }
        }
    }
}
