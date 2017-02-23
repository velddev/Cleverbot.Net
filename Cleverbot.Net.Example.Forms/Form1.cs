using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cleverbot.Net.Example.Forms
{
    public partial class Form1 : Form
    {
        const string defaultInputText = "Chat here, Press enter to send it.";

        // The program will not run, unless you add your api key or disable the test message

        //To disable:
        //Cleverbot cleverbot = new Cleverbot("your-api-key", false);
        Cleverbot cleverbot = new Cleverbot("3f4750604ead0d01f3c368954aae6608");

        public Form1()
        {
            InitializeComponent();
            this.Text = "Cleverbot Example";

            Label_Status.Text = "";

            Textbox_Input.Text = defaultInputText;
            Textbox_Input.ForeColor = Color.Gray;

            Textbox_Input.GotFocus += (s, e) =>
            {
                if (Textbox_Input.Text == defaultInputText)
                {
                    Textbox_Input.Text = "";
                }
                Textbox_Input.ForeColor = Color.Black;
            };

            Textbox_Input.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(Textbox_Input.Text))
                {
                    Textbox_Input.Text = defaultInputText;
                }
                Textbox_Input.ForeColor = Color.Gray;
            };

            // Is freezing on GetResponseAsync(...);
            Textbox_Input.KeyDown += (s, e) =>
            {
                if(e.KeyData == Keys.Enter)
                {
                    if (string.IsNullOrWhiteSpace(Textbox_Input.Text))
                    {
                        return;
                    }

                    SendMessage(Textbox_Input.Text, "You");
                    Textbox_Input.Text = "";

                    Label_Status.Text = "Cleverbot is typing...";
                    SendMessage(cleverbot.GetResponseAsync(Textbox_Input.Text).GetAwaiter().GetResult().Response, "Cleverbot");
                    Label_Status.Text = "";
                }
            };
        }

        void SendMessage(string message, string sender)
        {
            Textbox_MessageLog.AppendText(DateTime.Now.ToShortTimeString() + " - " + sender + ": " + message + "\n");
        }
    }
}
