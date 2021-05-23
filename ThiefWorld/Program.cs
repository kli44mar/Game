using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThiefWorld
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 
        public static ThiefWorld World;

        [STAThread]
        static void Main()
        {
            var player = new Character("Leo");
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ThiefWorld(player, new Architecture.ShopOutfit()));
            //Application.Run(new LevelMap(new Interface.Levels(), player));
        }

        /**
         * # ����
         * - ����� ��������� ���� ��� ������� ������ "������"
         * - ���� ��������� �� 5 �������
         * - ������ ������� ������� �� ���� ����������: �������������� �������, ��������������� �����-���� ������������������ �� ������ � ���������� ������(�������)
         * - ��� ����������� ������ ����� �������� �����-�� ���������� �����, ���������������� �������� � ���������� ����������� ������� �� ����������
         * - ������������ ������ ����� �������� �� �������� ������, ������� ���������� ������ � �� ������� � ������ ������� �����
         * - � ����� ���� �������� �������� ������ ����� �������� (��� ���������� ����� �����: ������, �������� ��� ��������������)
         * 
         * # ����
         * - ������ �������� � ���
         * - ����� ������: ������, �������, ������, ����������
         * 
         * # ��������
         * - ���
         * - ������
         * - ���������� �����
         * 
         * # �������
         * - ��� ���������
         * - ������������ ���������� ����� ����������� � ����������
         * - ��������������� ������, ��������� ����� ������
         * - ������� ��� ���������� ������������� ������, ����� ������ ������������� ���� ���������
         * 
         * # ����������: �������������� �������
         * - ������ 1 ������ �� ������� 8-6-5-3-2 ��������
         * - ���� ����� �� ����� ������ ������ ������, �� �� ����� ���������� ��� � ������ �����
         * - �� ������ ��������� �������� ������ ����� �������� 15-20-24-40-60 �����
         * 
         * # ����������: ��������������� �����-���� ������������������ �� ������
         * - � ����������� �� ������ ����� ��������������� 8-6-5-3-2 �������������������
         * - ���� �������� ���� �� ���� ������ � ������������������, ���������� �������������� ������� � ��������� ������������������
         * - �� ������ ��������� ���������������� ������������������ ����� �������� 15-20-24-40-60 �����
         * 
         * # ����������: ������ �� ����������������� � ������
         * - � ������ ������ ���� ���� ������
         * - �� ���� ���������� ����� �������� 120 �����
         * */
    }
}
