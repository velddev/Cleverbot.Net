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
        Cleverbot cleverbot = new Cleverbot("your-api-key");

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
            Textbox_Input.KeyDown += async (s, e) =>
            {
                if (e.KeyData == Keys.Enter)
                {
                    if (string.IsNullOrWhiteSpace(Textbox_Input.Text))
                    {
                        return;
                    }

                    SendMessage(Textbox_Input.Text, "You");
                    Textbox_Input.Text = "";

                    Label_Status.Text = "Cleverbot is typing...";

                   //SendMessage((await Task.Run(async () => { return (await cleverbot.GetResponseAsync(Textbox_Input.Text)).Response; })), "Cleverbot");    

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
