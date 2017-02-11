using OpenCNCPilot.Communication;
using OpenCNCPilot.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OpenCNCPilot
{
	partial class MainWindow
	{
		private List<string> ManualCommands = new List<string>();	//pos 0 is the last command sent, pos1+ are older
		private int ManualCommandIndex = -1;

		void ManualSend()
		{
			if (machine.Mode != Machine.OperatingMode.Manual)
				return;

			machine.SendLine(TextBoxManual.Text);

			ManualCommands.Insert(0, TextBoxManual.Text);
			ManualCommandIndex = -1;

			TextBoxManual.Text = "";
		}

		private void ButtonManualSend_Click(object sender, RoutedEventArgs e)
		{
			ManualSend();
		}

		private void TextBoxManual_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
		{
			if (e.Key == System.Windows.Input.Key.Enter)
			{
				e.Handled = true;
				ManualSend();
			}
			else if (e.Key == System.Windows.Input.Key.Down)
			{
				e.Handled = true;

				if (ManualCommandIndex == 0)
				{
					TextBoxManual.Text = "";
					ManualCommandIndex = -1;
				}
				else if (ManualCommandIndex > 0)
				{
					ManualCommandIndex--;
					TextBoxManual.Text = ManualCommands[ManualCommandIndex];
					TextBoxManual.SelectionStart = TextBoxManual.Text.Length;
				}
			}
			else if (e.Key == System.Windows.Input.Key.Up)
			{
				e.Handled = true;

				if (ManualCommands.Count > ManualCommandIndex + 1)
				{
					ManualCommandIndex++;
					TextBoxManual.Text = ManualCommands[ManualCommandIndex];
					TextBoxManual.SelectionStart = TextBoxManual.Text.Length;
				}
			}
		}

		private void ButtonManualSetG10Zero_Click(object sender, RoutedEventArgs e)
		{
			if (machine.Mode != Machine.OperatingMode.Manual)
				return;

			TextBoxManual.Text = $"G10 L2 P0 X{machine.WorkPosition.X.ToString(Constants.DecimalOutputFormat)} Y{machine.WorkPosition.Y.ToString(Constants.DecimalOutputFormat)} Z{machine.WorkPosition.Z.ToString(Constants.DecimalOutputFormat)}";
		}

		private void ButtonManualSetG92Zero_Click(object sender, RoutedEventArgs e)
		{
			if (machine.Mode != Machine.OperatingMode.Manual)
				return;

			TextBoxManual.Text = "G92 X0 Y0 Z0";
        }

		private void ButtonManualResetG10_Click(object sender, RoutedEventArgs e)
		{
			if (machine.Mode != Machine.OperatingMode.Manual)
				return;

			TextBoxManual.Text = "G10 L2 P0 X0 Y0 Z0";
        }


        // Commands for Jog Tab
        private void ButtonManualXDec_Click(object sender, RoutedEventArgs e)
        {
            if (machine.Mode != Machine.OperatingMode.Manual)
                return;

            TextBoxManual.Text = "G21 G91 G0  X-" + JogIncrement.Text;
            ManualSend();
        }

        private void ButtonManualXInc_Click(object sender, RoutedEventArgs e)
        {
            if (machine.Mode != Machine.OperatingMode.Manual)
                return;

            TextBoxManual.Text = "G21 G91 G0  X" + JogIncrement.Text;
            ManualSend();
        }

        private void ButtonManualYDec_Click(object sender, RoutedEventArgs e)
        {
            if (machine.Mode != Machine.OperatingMode.Manual)
                return;

            TextBoxManual.Text = "G21 G91 G0  Y-" + JogIncrement.Text;
            ManualSend();
        }

        private void ButtonManualYInc_Click(object sender, RoutedEventArgs e)
        {
            if (machine.Mode != Machine.OperatingMode.Manual)
                return;

            TextBoxManual.Text = "G21 G91 G0  Y" + JogIncrement.Text;
            ManualSend();
        }

        private void ButtonManualZDec_Click(object sender, RoutedEventArgs e)
        {
            if (machine.Mode != Machine.OperatingMode.Manual)
                return;

            TextBoxManual.Text = "G21 G91 G0  Z-" + JogIncrement.Text;
            ManualSend();
        }

        private void ButtonManualZInc_Click(object sender, RoutedEventArgs e)
        {
            if (machine.Mode != Machine.OperatingMode.Manual)
                return;

            TextBoxManual.Text = "G21 G91 G0  Z" + JogIncrement.Text;
            ManualSend();
        }

        private void Button100_Click(object sender, RoutedEventArgs e)
        {

            JogIncrement.Text = "100";
        }

        private void Button10_Click(object sender, RoutedEventArgs e)
        {

            JogIncrement.Text = "10";
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {

            JogIncrement.Text = "1";
        }

        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            if (machine.Mode != Machine.OperatingMode.Manual)
                return;

            TextBoxManual.Text = "$H";
            ManualSend();
        }

        private void ButtonX0Y0_Click(object sender, RoutedEventArgs e)
        {
            if (machine.Mode != Machine.OperatingMode.Manual)
                return;

            TextBoxManual.Text = "G90 G0 X0 Y0";
            ManualSend();
        }

        private void ButtonProbe_Click(object sender, RoutedEventArgs e)
        {
            if (machine.Mode != Machine.OperatingMode.Manual)
                return;

            TextBoxManual.Text = "G38.2 Z-10 F10";
            ManualSend();
        }

        private void Button_Zero_X_Click(object sender, RoutedEventArgs e)
        {
            if (machine.Mode != Machine.OperatingMode.Manual)
                return;

            TextBoxManual.Text = "G90 G10 L20 P0 X0";
            ManualSend();
        }

        private void Button_Zero_Y_Click(object sender, RoutedEventArgs e)
        {
            if (machine.Mode != Machine.OperatingMode.Manual)
                return;

            TextBoxManual.Text = "G90 G10 L20 P0 Y0";
            ManualSend();
        }

        private void Button_Zero_Z_Click(object sender, RoutedEventArgs e)
        {
            if (machine.Mode != Machine.OperatingMode.Manual)
                return;

            TextBoxManual.Text = "G90 G10 L20 P0 Z0";
            ManualSend();
        }

        private void Button_Start_Motor_Click(object sender, RoutedEventArgs e)
        {
            if (machine.Mode != Machine.OperatingMode.Manual)
                return;

            TextBoxManual.Text = "M03";
            ManualSend();
        }

        private void Button_Stop_Motor_Click(object sender, RoutedEventArgs e)
        {
            if (machine.Mode != Machine.OperatingMode.Manual)
                return;

            TextBoxManual.Text = "M05";
            ManualSend();
        }

        //Commands for Override Tab
        private void ButtonFeedInc10_Click(object sender, RoutedEventArgs e)
        {

            machine.OV_Command(0x91);
        }

        private void ButtonFeedDec10_Click(object sender, RoutedEventArgs e)
        {

            machine.OV_Command(0x92);
        }

        private void ButtonFeedInc1_Click(object sender, RoutedEventArgs e)
        {

            machine.OV_Command(0x93);
        }

        private void ButtonFeedDec1_Click(object sender, RoutedEventArgs e)
        {

            machine.OV_Command(0x94);
        }

        private void ButtonFeedReset_Click(object sender, RoutedEventArgs e)
        {

            machine.OV_Command(0x90);
        }

        private void ButtonRapid25_Click(object sender, RoutedEventArgs e)
        {

            machine.OV_Command(0x97);
        }

        private void ButtonRapid50_Click(object sender, RoutedEventArgs e)
        {

            machine.OV_Command(0x96);
        }


        private void ButtonRapidReset_Click(object sender, RoutedEventArgs e)
        {

            machine.OV_Command(0x95);
        }

        private void ButtonSpindleInc10_Click(object sender, RoutedEventArgs e)
        {

            machine.OV_Command(0x9A);
        }

        private void ButtonSpindleDec10_Click(object sender, RoutedEventArgs e)
        {

            machine.OV_Command(0x9B);
        }

        private void ButtonSpindleInc1_Click(object sender, RoutedEventArgs e)
        {

            machine.OV_Command(0x9C);
        }

        private void ButtonSpindleDec1_Click(object sender, RoutedEventArgs e)
        {

            machine.OV_Command(0x9D);
        }

        private void ButtonSpindleReset_Click(object sender, RoutedEventArgs e)
        {

            machine.OV_Command(0x99);
        }
    }
}
