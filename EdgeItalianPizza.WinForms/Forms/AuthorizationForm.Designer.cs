namespace EdgeItalianPizza.WinForms.Forms;

partial class AuthorizationForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        backgroundPanel = new Panel();
        titleLabel = new Label();
        loginLabel = new Label();
        loginTextBox = new TextBox();
        passwordTextBox = new TextBox();
        passwordLabel = new Label();
        entryButton = new Button();
        label1 = new Label();
        registrationLabel = new LinkLabel();
        backgroundPanel.SuspendLayout();
        SuspendLayout();
        // 
        // backgroundPanel
        // 
        backgroundPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        backgroundPanel.BackColor = Color.DodgerBlue;
        backgroundPanel.Controls.Add(titleLabel);
        backgroundPanel.Location = new Point(0, 0);
        backgroundPanel.Name = "backgroundPanel";
        backgroundPanel.Size = new Size(305, 120);
        backgroundPanel.TabIndex = 0;
        // 
        // titleLabel
        // 
        titleLabel.Font = new Font("Segoe UI Semibold", 26F, FontStyle.Bold);
        titleLabel.ForeColor = SystemColors.Control;
        titleLabel.Location = new Point(0, 0);
        titleLabel.Name = "titleLabel";
        titleLabel.Size = new Size(305, 120);
        titleLabel.TabIndex = 0;
        titleLabel.Text = "Вход";
        titleLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // loginLabel
        // 
        loginLabel.AutoSize = true;
        loginLabel.Font = new Font("Segoe UI Symbol", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        loginLabel.ForeColor = Color.Black;
        loginLabel.Location = new Point(12, 162);
        loginLabel.Name = "loginLabel";
        loginLabel.Size = new Size(54, 20);
        loginLabel.TabIndex = 1;
        loginLabel.Text = "Логин:";
        // 
        // loginTextBox
        // 
        loginTextBox.BackColor = SystemColors.Control;
        loginTextBox.BorderStyle = BorderStyle.FixedSingle;
        loginTextBox.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
        loginTextBox.Location = new Point(22, 185);
        loginTextBox.Multiline = true;
        loginTextBox.Name = "loginTextBox";
        loginTextBox.Size = new Size(260, 35);
        loginTextBox.TabIndex = 2;
        // 
        // passwordTextBox
        // 
        passwordTextBox.BackColor = SystemColors.Control;
        passwordTextBox.BorderStyle = BorderStyle.FixedSingle;
        passwordTextBox.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
        passwordTextBox.Location = new Point(22, 267);
        passwordTextBox.Multiline = true;
        passwordTextBox.Name = "passwordTextBox";
        passwordTextBox.Size = new Size(260, 35);
        passwordTextBox.TabIndex = 4;
        // 
        // passwordLabel
        // 
        passwordLabel.AutoSize = true;
        passwordLabel.Font = new Font("Segoe UI Symbol", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        passwordLabel.ForeColor = Color.Black;
        passwordLabel.Location = new Point(12, 244);
        passwordLabel.Name = "passwordLabel";
        passwordLabel.Size = new Size(65, 20);
        passwordLabel.TabIndex = 3;
        passwordLabel.Text = "Пароль:";
        // 
        // entryButton
        // 
        entryButton.AutoSize = true;
        entryButton.BackColor = Color.DodgerBlue;
        entryButton.FlatStyle = FlatStyle.Flat;
        entryButton.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
        entryButton.ForeColor = SystemColors.Control;
        entryButton.Location = new Point(105, 335);
        entryButton.Name = "entryButton";
        entryButton.Size = new Size(100, 40);
        entryButton.TabIndex = 5;
        entryButton.Text = "Войти";
        entryButton.UseVisualStyleBackColor = false;
        entryButton.Click += EntryButton_Click;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new Font("Segoe UI", 9.75F);
        label1.Location = new Point(12, 412);
        label1.Name = "label1";
        label1.Size = new Size(153, 17);
        label1.TabIndex = 6;
        label1.Text = "Все ещё не наш клиент?";
        // 
        // registrationLabel
        // 
        registrationLabel.ActiveLinkColor = Color.DodgerBlue;
        registrationLabel.AutoSize = true;
        registrationLabel.Font = new Font("Segoe UI", 9.75F);
        registrationLabel.LinkColor = Color.DodgerBlue;
        registrationLabel.Location = new Point(162, 412);
        registrationLabel.Name = "registrationLabel";
        registrationLabel.Size = new Size(130, 17);
        registrationLabel.TabIndex = 7;
        registrationLabel.TabStop = true;
        registrationLabel.Text = "Зарегистрироваться";
        registrationLabel.LinkClicked += RegistrationLabel_LinkClicked;
        // 
        // AuthorizationForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.Control;
        ClientSize = new Size(304, 441);
        Controls.Add(registrationLabel);
        Controls.Add(label1);
        Controls.Add(entryButton);
        Controls.Add(passwordTextBox);
        Controls.Add(passwordLabel);
        Controls.Add(loginTextBox);
        Controls.Add(loginLabel);
        Controls.Add(backgroundPanel);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "AuthorizationForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "EdgeItalianPizza";
        Load += AuthorizationForm_Load;
        backgroundPanel.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Panel backgroundPanel;
    private Label titleLabel;
    private Label loginLabel;
    private TextBox loginTextBox;
    private TextBox passwordTextBox;
    private Label passwordLabel;
    private Button entryButton;
    private Label label1;
    private LinkLabel registrationLabel;
}