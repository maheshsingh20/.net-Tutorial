using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Feb11
{
    public class Form1 : Form
    {
        Label lblName, lblAge, lblEmail, lblPhone, lblAddress;
        TextBox txtName, txtAge, txtEmail, txtPhone, txtAddress;
        Button btnSubmit;

        public Form1()
        {
            this.Text = "Student Registration Form";
            this.Size = new Size(400, 400);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Labels
            lblName = new Label() { Text = "Name:", Location = new Point(30, 30) };
            lblAge = new Label() { Text = "Age:", Location = new Point(30, 70) };
            lblEmail = new Label() { Text = "Email:", Location = new Point(30, 110) };
            lblPhone = new Label() { Text = "Phone:", Location = new Point(30, 150) };
            lblAddress = new Label() { Text = "Address:", Location = new Point(30, 190) };

            // TextBoxes
            txtName = new TextBox() { Location = new Point(120, 30), Width = 200 };
            txtAge = new TextBox() { Location = new Point(120, 70), Width = 200 };
            txtEmail = new TextBox() { Location = new Point(120, 110), Width = 200 };
            txtPhone = new TextBox() { Location = new Point(120, 150), Width = 200 };
            txtAddress = new TextBox() { Location = new Point(120, 190), Width = 200 };

            // Button
            btnSubmit = new Button()
            {
                Text = "Submit",
                Location = new Point(120, 240),
                Width = 100
            };

            btnSubmit.Click += BtnSubmit_Click;

            // Add Controls to Form
            this.Controls.Add(lblName);
            this.Controls.Add(lblAge);
            this.Controls.Add(lblEmail);
            this.Controls.Add(lblPhone);
            this.Controls.Add(lblAddress);

            this.Controls.Add(txtName);
            this.Controls.Add(txtAge);
            this.Controls.Add(txtEmail);
            this.Controls.Add(txtPhone);
            this.Controls.Add(txtAddress);

            this.Controls.Add(btnSubmit);
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtAge.Text == "" || txtEmail.Text == "" ||
                txtPhone.Text == "" || txtAddress.Text == "")
            {
                MessageBox.Show("All fields are required!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show(
                "Name: " + txtName.Text + "\n" +
                "Age: " + txtAge.Text + "\n" +
                "Email: " + txtEmail.Text + "\n" +
                "Phone: " + txtPhone.Text + "\n" +
                "Address: " + txtAddress.Text,
                "Form Submitted",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            // Clear fields
            txtName.Clear();
            txtAge.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
        }

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
    }
}
