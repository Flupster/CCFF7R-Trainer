using System.Diagnostics;
using System.Runtime.InteropServices;

namespace CCFF7R_Trainer
{

    internal class GameMemory
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess, Int64 lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(int hProcess, Int64 lpBaseAddress, byte[] lpBuffer, uint nSize, out int returnVal);


        public Process? process;
        public Int32 processHandle;

        public struct Enemy
        {
            public Int32 ID;
            public Int32 HP;
            public Int32 MaxHP;
        }

        public GameMemory()
        {
            process = Process.GetProcessesByName("CCFF7R-Win64-Shipping").FirstOrDefault();
            if (process == null) return;
            processHandle = (int)OpenProcess(0x0010, false, process.Id);
        }


        public void KillPlayer()
        {
            int writeHandle = (int)OpenProcess(0x001F0FFF, false, process.Id);
            Int64 deathAddress = IntPtr.Add(process.Modules[0].BaseAddress, 0x0718DC8A).ToInt64();
            Int64 zackHpAddress = IntPtr.Add(process.Modules[0].BaseAddress, 0x0718DC28).ToInt64();
            Int32 returnval = 0;
            WriteProcessMemory(writeHandle, deathAddress, new byte[] { (byte)1 }, 1, out returnval);
            WriteProcessMemory(writeHandle, zackHpAddress, BitConverter.GetBytes(0), 4, out returnval);
        }

        public byte GetBattleState()
        {
            byte[] buffer = new byte[1];
            int bytesRead = 0;
            Int64 pointer = IntPtr.Add(process.Modules[0].BaseAddress, 0x0717AD5C).ToInt64();
            ReadProcessMemory(processHandle, pointer, buffer, buffer.Length, ref bytesRead);
            return buffer[0];
        }

        public void SetBattleState(Byte val)
        {
            int writeHandle = (int)OpenProcess(0x001F0FFF, false, process.Id);
            Int64 pointer = IntPtr.Add(process.Modules[0].BaseAddress, 0x0717AD5C).ToInt64();
            Int32 returnval = 0;
            WriteProcessMemory(writeHandle, pointer, new byte[] { (byte)val }, 1, out returnval);
        }

        public Enemy[] GetEnemies()
        {
            Enemy[] enemies = new Enemy[13];

            for (int i = 0; i < 13; i++)
            {
                byte[] buffer = new byte[250];
                int bytesRead = 0;
                Int64 pointer = IntPtr.Add(process.Modules[0].BaseAddress, 0x07194F38 + (i * 0x0740)).ToInt64();
                ReadProcessMemory(processHandle, pointer, buffer, buffer.Length, ref bytesRead);
                Enemy enemy = new Enemy();
                enemy.ID = BitConverter.ToInt32(buffer, 0);
                enemy.HP = BitConverter.ToInt32(buffer, 240);
                enemy.MaxHP = BitConverter.ToInt32(buffer, 244);
                enemies[i] = enemy;
            }

            return enemies;
        }

        public Int32 GetZacksHP()
        {
            byte[] buffer = new byte[4];
            int bytesRead = 0;
            Int64 pointer = IntPtr.Add(process.Modules[0].BaseAddress, 0x0718DC28).ToInt64();
            ReadProcessMemory(processHandle, pointer, buffer, buffer.Length, ref bytesRead);
            return BitConverter.ToInt32(buffer);
        }

    }
}
