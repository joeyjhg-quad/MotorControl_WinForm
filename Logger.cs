using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorControl_WinForm
{
    public static class Logger
    {
        private static Main _form;

        // Form1을 등록하는 메서드
        public static void Initialize(Main form)
        {
            _form = form;
        }

        // 로그 출력 메서드 (richTextBox1 사용)
        public static void Log(string message)
        {
            if (_form == null || _form.IsDisposed) return;

            if (_form.InvokeRequired)
            {
                _form.Invoke(new Action(() => Log(message)));
                return;
            }

            _form.richTextBox1.AppendText($"{DateTime.Now:HH:mm:ss} - {message}\r\n");

            // 가장 아래로 스크롤
            _form.richTextBox1.SelectionStart = _form.richTextBox1.Text.Length;
            _form.richTextBox1.ScrollToCaret();
        }
    }


}
