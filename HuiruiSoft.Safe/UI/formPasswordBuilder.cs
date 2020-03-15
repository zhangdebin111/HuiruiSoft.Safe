using System.Windows.Forms;
using HuiruiSoft.Utils;
using HuiruiSoft.Safe.Resources;
using HuiruiSoft.Safe.Configuration;
using HuiruiSoft.Security.Cryptography;

namespace HuiruiSoft.Safe
{
     public partial class formPasswordBuilder : System.Windows.Forms.Form
     {
          private static readonly log4net.ILog loger = log4net.LogManager.GetLogger("loger");

          private bool blockUpdateControls = false;

          private System.ComponentModel.IContainer components = null;
          private System.Windows.Forms.Button buttonGenerate;
          private System.Windows.Forms.Button buttonCopy;
          private System.Windows.Forms.Button buttonOK;
          private System.Windows.Forms.Button buttonCancel;
          private System.Windows.Forms.Label labelPasswordLength;
          private System.Windows.Forms.TextBox textExcludeChars;
          private System.Windows.Forms.GroupBox groupPasswordOptions;
          private System.Windows.Forms.GroupBox groupAdvancedOptions;
          private System.Windows.Forms.GroupBox groupGeneratePassword;
          private System.Windows.Forms.CheckBox checkUpperCase;
          private System.Windows.Forms.CheckBox checkLowerCase;
          private System.Windows.Forms.CheckBox checkDigitChars;
          private System.Windows.Forms.CheckBox checkMinusChar;
          private System.Windows.Forms.CheckBox checkUnderline;
          private System.Windows.Forms.CheckBox checkSpaceChar;
          private System.Windows.Forms.CheckBox checkSpecialChars;
          private System.Windows.Forms.CheckBox checkBracketChars;
          private System.Windows.Forms.CheckBox checkExcludeChars;
          private System.Windows.Forms.CheckBox checkNoRepeatingChars;
          private System.Windows.Forms.CheckBox checkExcludeLookAlike;
          private System.Windows.Forms.RadioButton radioUsingNumeral;
          private System.Windows.Forms.RadioButton radioUsingCharacter;
          private System.Windows.Forms.RichTextBox textBoxPassword;
          private System.Windows.Forms.NumericUpDown numericPasswordLength;

          private PasswordGeneratorProfile originalProfile = null;

          public string PasswordString
          {
               get;
               private set;
          }

          internal formPasswordBuilder()
          {
               this.InitializeComponent();

               this.MinimizeBox = false;
               this.MaximizeBox = false;
               this.ShowInTaskbar = false;
               this.WindowState = FormWindowState.Normal;
               this.FormBorderStyle = FormBorderStyle.FixedDialog;
               this.StartPosition = FormStartPosition.CenterScreen;
          }

          protected override void OnLoad(System.EventArgs args)
          {
               base.OnLoad(args);

               if (!base.DesignMode)
               {
                    this.blockUpdateControls = true;

                    this.CancelButton = this.buttonCancel;
                    this.numericPasswordLength.Minimum = 1;
                    this.numericPasswordLength.Maximum = 100;
                    this.numericPasswordLength.Value = 16;
                    this.textExcludeChars.ImeMode = ImeMode.Disable;

                    this.textBoxPassword.ReadOnly = true;
                    this.textBoxPassword.Multiline = true;
                    this.textBoxPassword.SelectionAlignment = HorizontalAlignment.Center;

                    this.Icon = WindowsUtils.DefaultAppIcon;
                    this.Text = SafePassResource.PasswordGeneratorWindowCaption;
                    this.buttonOK.Text = SafePassResource.ButtonOK;
                    this.buttonCancel.Text = SafePassResource.ButtonCancel;

                    this.buttonGenerate.Text = SafePassResource.PasswordGeneratorButtonGenerate;
                    this.groupPasswordOptions.Text = SafePassResource.PasswordGeneratorPasswordOptions;
                    this.groupAdvancedOptions.Text = SafePassResource.PasswordGeneratorAdvancedOptions;
                    this.groupGeneratePassword.Text = SafePassResource.PasswordGeneratorGroupPassword;
                    this.radioUsingNumeral.Text = SafePassResource.PasswordGeneratorRadioUsingNumeral;
                    this.radioUsingCharacter.Text = SafePassResource.PasswordGeneratorRadioUsingCharacter;
                    this.labelPasswordLength.Text = SafePassResource.PasswordGeneratorLabelPasswordLength;

                    this.checkUpperCase.Text = SafePassResource.PasswordGeneratorCheckBoxUpperCase;
                    this.checkLowerCase.Text = SafePassResource.PasswordGeneratorCheckBoxLowerCase;
                    this.checkDigitChars.Text = SafePassResource.PasswordGeneratorCheckBoxDigitChars;
                    this.checkMinusChar.Text = SafePassResource.PasswordGeneratorCheckBoxMinusChar;
                    this.checkUnderline.Text = SafePassResource.PasswordGeneratorCheckBoxUnderline;
                    this.checkSpaceChar.Text = SafePassResource.PasswordGeneratorCheckBoxSpaceChar;
                    this.checkSpecialChars.Text = SafePassResource.PasswordGeneratorCheckBoxSpecialChars;
                    this.checkBracketChars.Text = SafePassResource.PasswordGeneratorCheckBoxBracketChars;
                    this.checkExcludeChars.Text = SafePassResource.PasswordGeneratorCheckBoxExcludeChars;
                    this.checkNoRepeatingChars.Text = SafePassResource.PasswordGeneratorCheckBoxNoRepeatingChars;
                    this.checkExcludeLookAlike.Text = SafePassResource.PasswordGeneratorCheckBoxExcludeLookAlike;

                    this.checkUpperCase.Text += " (A, B, C, B, B, ...)";
                    this.checkLowerCase.Text += " (a, b, c, b, b, ...)";
                    this.checkDigitChars.Text += " (0, 1, 2, 3, 4, 5, ...)";
                    this.checkMinusChar.Text += " (-)";
                    this.checkUnderline.Text += " (_)";
                    this.checkSpaceChar.Text += " ( )";
                    this.checkBracketChars.Text += " ([, ], {, }, (, ), <, >)";
                    this.checkSpecialChars.Text += " (!, $, %, &&, #, *, +, :, ;, =, ?, @, \", ', ^, `, ~, ,, ., |, \\, /)";
                    this.checkExcludeLookAlike.Text += " (O0, l|1I)";

                    this.originalProfile = Program.Config.Application.PasswordGenerator;

                    this.radioUsingNumeral.Checked = this.originalProfile.UsingAllNumeric;
                    this.radioUsingCharacter.Checked = !this.radioUsingNumeral.Checked;
                    this.checkUpperCase.Checked = this.originalProfile.UsingUpperCase;
                    this.checkLowerCase.Checked = this.originalProfile.UsingLowerCase;
                    this.checkDigitChars.Checked = this.originalProfile.UsingDigitChars;
                    this.checkMinusChar.Checked = this.originalProfile.UsingMinusChar;
                    this.checkUnderline.Checked = this.originalProfile.UsingUnderline;
                    this.checkSpaceChar.Checked = this.originalProfile.UsingSpaceChar;
                    this.checkSpecialChars.Checked = this.originalProfile.UsingSpecialChars;
                    this.checkBracketChars.Checked = this.originalProfile.UsingBracketChars;

                    if (this.originalProfile.Length >= this.numericPasswordLength.Minimum && this.originalProfile.Length <= this.numericPasswordLength.Maximum)
                    {
                         this.numericPasswordLength.Value = this.originalProfile.Length;
                    }

                    this.checkNoRepeatingChars.Checked = this.originalProfile.NoRepeatingChars;
                    this.checkExcludeLookAlike.Checked = this.originalProfile.ExcludeLookAlike;
                    if (string.IsNullOrEmpty(this.originalProfile.ExcludeCharacters))
                    {
                         this.checkExcludeChars.Checked = false;
                    }
                    else
                    {
                         this.checkExcludeChars.Checked = true;
                         this.textExcludeChars.Text = this.originalProfile.ExcludeCharacters;
                    }

                    this.blockUpdateControls = false;
                    this.UpdateControlState();
               }
          }

          protected override void OnClosed(System.EventArgs args)
          {
               base.OnClosed(args);
          }

          protected override void Dispose(bool disposing)
          {
               if (disposing && (components != null))
               {
                    components.Dispose();
               }
               base.Dispose(disposing);
          }

          #region Windows 窗体设计器生成的代码

          private void InitializeComponent()
          {
               this.buttonGenerate = new System.Windows.Forms.Button();
               this.numericPasswordLength = new System.Windows.Forms.NumericUpDown();
               this.checkUpperCase = new System.Windows.Forms.CheckBox();
               this.checkLowerCase = new System.Windows.Forms.CheckBox();
               this.checkDigitChars = new System.Windows.Forms.CheckBox();
               this.checkMinusChar = new System.Windows.Forms.CheckBox();
               this.checkUnderline = new System.Windows.Forms.CheckBox();
               this.checkSpaceChar = new System.Windows.Forms.CheckBox();
               this.checkSpecialChars = new System.Windows.Forms.CheckBox();
               this.checkBracketChars = new System.Windows.Forms.CheckBox();
               this.labelPasswordLength = new System.Windows.Forms.Label();
               this.radioUsingNumeral = new System.Windows.Forms.RadioButton();
               this.radioUsingCharacter = new System.Windows.Forms.RadioButton();
               this.groupPasswordOptions = new System.Windows.Forms.GroupBox();
               this.groupGeneratePassword = new System.Windows.Forms.GroupBox();
               this.textBoxPassword = new System.Windows.Forms.RichTextBox();
               this.buttonOK = new System.Windows.Forms.Button();
               this.buttonCancel = new System.Windows.Forms.Button();
               this.groupAdvancedOptions = new System.Windows.Forms.GroupBox();
               this.textExcludeChars = new System.Windows.Forms.TextBox();
               this.checkNoRepeatingChars = new System.Windows.Forms.CheckBox();
               this.checkExcludeLookAlike = new System.Windows.Forms.CheckBox();
               this.checkExcludeChars = new System.Windows.Forms.CheckBox();
               this.buttonCopy = new System.Windows.Forms.Button();
               ((System.ComponentModel.ISupportInitialize)(this.numericPasswordLength)).BeginInit();
               this.groupPasswordOptions.SuspendLayout();
               this.groupGeneratePassword.SuspendLayout();
               this.groupAdvancedOptions.SuspendLayout();
               this.SuspendLayout();
               // 
               // buttonGenerate
               // 
               this.buttonGenerate.Location = new System.Drawing.Point(1062, 56);
               this.buttonGenerate.Margin = new System.Windows.Forms.Padding(6);
               this.buttonGenerate.Name = "buttonGenerate";
               this.buttonGenerate.Size = new System.Drawing.Size(173, 82);
               this.buttonGenerate.TabIndex = 1;
               this.buttonGenerate.Text = "&Generate";
               this.buttonGenerate.UseVisualStyleBackColor = true;
               this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
               // 
               // numericPasswordLength
               // 
               this.numericPasswordLength.Location = new System.Drawing.Point(365, 254);
               this.numericPasswordLength.Margin = new System.Windows.Forms.Padding(4);
               this.numericPasswordLength.Name = "numericPasswordLength";
               this.numericPasswordLength.Size = new System.Drawing.Size(180, 28);
               this.numericPasswordLength.TabIndex = 11;
               this.numericPasswordLength.ValueChanged += new System.EventHandler(this.numericPasswordLength_ValueChanged);
               // 
               // checkUpperCase
               // 
               this.checkUpperCase.AutoSize = true;
               this.checkUpperCase.Location = new System.Drawing.Point(88, 121);
               this.checkUpperCase.Margin = new System.Windows.Forms.Padding(4);
               this.checkUpperCase.Name = "checkUpperCase";
               this.checkUpperCase.Size = new System.Drawing.Size(124, 22);
               this.checkUpperCase.TabIndex = 2;
               this.checkUpperCase.Text = "&Upper-case";
               this.checkUpperCase.UseVisualStyleBackColor = true;
               this.checkUpperCase.CheckedChanged += new System.EventHandler(this.checkUpperCase_CheckedChanged);
               // 
               // checkLowerCase
               // 
               this.checkLowerCase.AutoSize = true;
               this.checkLowerCase.Location = new System.Drawing.Point(88, 164);
               this.checkLowerCase.Margin = new System.Windows.Forms.Padding(4);
               this.checkLowerCase.Name = "checkLowerCase";
               this.checkLowerCase.Size = new System.Drawing.Size(124, 22);
               this.checkLowerCase.TabIndex = 5;
               this.checkLowerCase.Text = "Lo&wer-case";
               this.checkLowerCase.UseVisualStyleBackColor = true;
               this.checkLowerCase.CheckedChanged += new System.EventHandler(this.checkLowerCase_CheckedChanged);
               // 
               // checkDigitChars
               // 
               this.checkDigitChars.AutoSize = true;
               this.checkDigitChars.Location = new System.Drawing.Point(88, 207);
               this.checkDigitChars.Margin = new System.Windows.Forms.Padding(4);
               this.checkDigitChars.Name = "checkDigitChars";
               this.checkDigitChars.Size = new System.Drawing.Size(88, 22);
               this.checkDigitChars.TabIndex = 8;
               this.checkDigitChars.Text = "&Digits";
               this.checkDigitChars.UseVisualStyleBackColor = true;
               this.checkDigitChars.CheckedChanged += new System.EventHandler(this.checkDigitChars_CheckedChanged);
               // 
               // checkMinusChar
               // 
               this.checkMinusChar.AutoSize = true;
               this.checkMinusChar.Location = new System.Drawing.Point(821, 121);
               this.checkMinusChar.Margin = new System.Windows.Forms.Padding(4);
               this.checkMinusChar.Name = "checkMinusChar";
               this.checkMinusChar.Size = new System.Drawing.Size(79, 22);
               this.checkMinusChar.TabIndex = 4;
               this.checkMinusChar.Text = "&Minus";
               this.checkMinusChar.UseVisualStyleBackColor = true;
               this.checkMinusChar.CheckedChanged += new System.EventHandler(this.checkMinusChar_CheckedChanged);
               // 
               // checkUnderline
               // 
               this.checkUnderline.AutoSize = true;
               this.checkUnderline.Location = new System.Drawing.Point(821, 164);
               this.checkUnderline.Margin = new System.Windows.Forms.Padding(4);
               this.checkUnderline.Name = "checkUnderline";
               this.checkUnderline.Size = new System.Drawing.Size(115, 22);
               this.checkUnderline.TabIndex = 7;
               this.checkUnderline.Text = "U&nderline";
               this.checkUnderline.UseVisualStyleBackColor = true;
               this.checkUnderline.CheckedChanged += new System.EventHandler(this.checkUnderline_CheckedChanged);
               // 
               // checkSpaceChar
               // 
               this.checkSpaceChar.AutoSize = true;
               this.checkSpaceChar.Location = new System.Drawing.Point(477, 121);
               this.checkSpaceChar.Margin = new System.Windows.Forms.Padding(4);
               this.checkSpaceChar.Name = "checkSpaceChar";
               this.checkSpaceChar.Size = new System.Drawing.Size(79, 22);
               this.checkSpaceChar.TabIndex = 3;
               this.checkSpaceChar.Text = "&Space";
               this.checkSpaceChar.UseVisualStyleBackColor = true;
               this.checkSpaceChar.CheckedChanged += new System.EventHandler(this.checkSpaceChar_CheckedChanged);
               // 
               // checkSpecialChars
               // 
               this.checkSpecialChars.AutoSize = true;
               this.checkSpecialChars.Location = new System.Drawing.Point(477, 207);
               this.checkSpecialChars.Margin = new System.Windows.Forms.Padding(4);
               this.checkSpecialChars.Name = "checkSpecialChars";
               this.checkSpecialChars.Size = new System.Drawing.Size(97, 22);
               this.checkSpecialChars.TabIndex = 9;
               this.checkSpecialChars.Text = "Sp&ecial";
               this.checkSpecialChars.UseVisualStyleBackColor = true;
               this.checkSpecialChars.CheckedChanged += new System.EventHandler(this.checkSpecialChars_CheckedChanged);
               // 
               // checkBracketChars
               // 
               this.checkBracketChars.AutoSize = true;
               this.checkBracketChars.Location = new System.Drawing.Point(477, 164);
               this.checkBracketChars.Margin = new System.Windows.Forms.Padding(4);
               this.checkBracketChars.Name = "checkBracketChars";
               this.checkBracketChars.Size = new System.Drawing.Size(106, 22);
               this.checkBracketChars.TabIndex = 6;
               this.checkBracketChars.Text = "&Brackets";
               this.checkBracketChars.UseVisualStyleBackColor = true;
               this.checkBracketChars.CheckedChanged += new System.EventHandler(this.checkBracketChars_CheckedChanged);
               // 
               // labelPasswordLength
               // 
               this.labelPasswordLength.Location = new System.Drawing.Point(58, 253);
               this.labelPasswordLength.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
               this.labelPasswordLength.Name = "labelPasswordLength";
               this.labelPasswordLength.Size = new System.Drawing.Size(300, 30);
               this.labelPasswordLength.TabIndex = 10;
               this.labelPasswordLength.Text = "&Length of generated password:";
               this.labelPasswordLength.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
               // 
               // radioUsingNumeral
               // 
               this.radioUsingNumeral.AutoSize = true;
               this.radioUsingNumeral.Location = new System.Drawing.Point(50, 38);
               this.radioUsingNumeral.Margin = new System.Windows.Forms.Padding(4);
               this.radioUsingNumeral.Name = "radioUsingNumeral";
               this.radioUsingNumeral.Size = new System.Drawing.Size(132, 22);
               this.radioUsingNumeral.TabIndex = 0;
               this.radioUsingNumeral.TabStop = true;
               this.radioUsingNumeral.Text = "All numeric";
               this.radioUsingNumeral.UseVisualStyleBackColor = true;
               this.radioUsingNumeral.CheckedChanged += new System.EventHandler(this.radioUsingNumeral_CheckedChanged);
               // 
               // radioUsingCharacter
               // 
               this.radioUsingCharacter.AutoSize = true;
               this.radioUsingCharacter.Location = new System.Drawing.Point(50, 80);
               this.radioUsingCharacter.Margin = new System.Windows.Forms.Padding(4);
               this.radioUsingCharacter.Name = "radioUsingCharacter";
               this.radioUsingCharacter.Size = new System.Drawing.Size(294, 22);
               this.radioUsingCharacter.TabIndex = 1;
               this.radioUsingCharacter.TabStop = true;
               this.radioUsingCharacter.Text = "&Generate using character set:";
               this.radioUsingCharacter.UseVisualStyleBackColor = true;
               this.radioUsingCharacter.CheckedChanged += new System.EventHandler(this.radioUsingCharacter_CheckedChanged);
               // 
               // groupPasswordOptions
               // 
               this.groupPasswordOptions.Controls.Add(this.checkSpaceChar);
               this.groupPasswordOptions.Controls.Add(this.labelPasswordLength);
               this.groupPasswordOptions.Controls.Add(this.radioUsingNumeral);
               this.groupPasswordOptions.Controls.Add(this.numericPasswordLength);
               this.groupPasswordOptions.Controls.Add(this.radioUsingCharacter);
               this.groupPasswordOptions.Controls.Add(this.checkUpperCase);
               this.groupPasswordOptions.Controls.Add(this.checkSpecialChars);
               this.groupPasswordOptions.Controls.Add(this.checkBracketChars);
               this.groupPasswordOptions.Controls.Add(this.checkUnderline);
               this.groupPasswordOptions.Controls.Add(this.checkMinusChar);
               this.groupPasswordOptions.Controls.Add(this.checkLowerCase);
               this.groupPasswordOptions.Controls.Add(this.checkDigitChars);
               this.groupPasswordOptions.Location = new System.Drawing.Point(20, 27);
               this.groupPasswordOptions.Margin = new System.Windows.Forms.Padding(4);
               this.groupPasswordOptions.Name = "groupPasswordOptions";
               this.groupPasswordOptions.Padding = new System.Windows.Forms.Padding(4);
               this.groupPasswordOptions.Size = new System.Drawing.Size(1245, 300);
               this.groupPasswordOptions.TabIndex = 0;
               this.groupPasswordOptions.TabStop = false;
               this.groupPasswordOptions.Text = "Password options";
               // 
               // groupGeneratePassword
               // 
               this.groupGeneratePassword.Controls.Add(this.textBoxPassword);
               this.groupGeneratePassword.Controls.Add(this.buttonGenerate);
               this.groupGeneratePassword.Location = new System.Drawing.Point(20, 569);
               this.groupGeneratePassword.Margin = new System.Windows.Forms.Padding(4);
               this.groupGeneratePassword.Name = "groupGeneratePassword";
               this.groupGeneratePassword.Padding = new System.Windows.Forms.Padding(4);
               this.groupGeneratePassword.Size = new System.Drawing.Size(1245, 177);
               this.groupGeneratePassword.TabIndex = 2;
               this.groupGeneratePassword.TabStop = false;
               this.groupGeneratePassword.Text = "Generated password";
               // 
               // textBoxPassword
               // 
               this.textBoxPassword.Location = new System.Drawing.Point(17, 43);
               this.textBoxPassword.Name = "textBoxPassword";
               this.textBoxPassword.Size = new System.Drawing.Size(1036, 106);
               this.textBoxPassword.TabIndex = 0;
               this.textBoxPassword.Text = "";
               // 
               // buttonOK
               // 
               this.buttonOK.Location = new System.Drawing.Point(851, 779);
               this.buttonOK.Name = "buttonOK";
               this.buttonOK.Size = new System.Drawing.Size(180, 49);
               this.buttonOK.TabIndex = 4;
               this.buttonOK.Text = "&OK";
               this.buttonOK.UseVisualStyleBackColor = true;
               this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
               // 
               // buttonCancel
               // 
               this.buttonCancel.Location = new System.Drawing.Point(1075, 779);
               this.buttonCancel.Name = "buttonCancel";
               this.buttonCancel.Size = new System.Drawing.Size(180, 49);
               this.buttonCancel.TabIndex = 5;
               this.buttonCancel.Text = "Close";
               this.buttonCancel.UseVisualStyleBackColor = true;
               this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
               // 
               // groupAdvancedOptions
               // 
               this.groupAdvancedOptions.Controls.Add(this.textExcludeChars);
               this.groupAdvancedOptions.Controls.Add(this.checkNoRepeatingChars);
               this.groupAdvancedOptions.Controls.Add(this.checkExcludeLookAlike);
               this.groupAdvancedOptions.Controls.Add(this.checkExcludeChars);
               this.groupAdvancedOptions.Location = new System.Drawing.Point(23, 357);
               this.groupAdvancedOptions.Margin = new System.Windows.Forms.Padding(4);
               this.groupAdvancedOptions.Name = "groupAdvancedOptions";
               this.groupAdvancedOptions.Padding = new System.Windows.Forms.Padding(4);
               this.groupAdvancedOptions.Size = new System.Drawing.Size(1245, 184);
               this.groupAdvancedOptions.TabIndex = 1;
               this.groupAdvancedOptions.TabStop = false;
               this.groupAdvancedOptions.Text = "Advanced options";
               // 
               // textExcludeChars
               // 
               this.textExcludeChars.Location = new System.Drawing.Point(345, 132);
               this.textExcludeChars.Name = "textExcludeChars";
               this.textExcludeChars.Size = new System.Drawing.Size(681, 28);
               this.textExcludeChars.TabIndex = 3;
               this.textExcludeChars.TextChanged += new System.EventHandler(this.textExcludeChars_TextChanged);
               // 
               // checkNoRepeatingChars
               // 
               this.checkNoRepeatingChars.AutoSize = true;
               this.checkNoRepeatingChars.Location = new System.Drawing.Point(85, 42);
               this.checkNoRepeatingChars.Margin = new System.Windows.Forms.Padding(4);
               this.checkNoRepeatingChars.Name = "checkNoRepeatingChars";
               this.checkNoRepeatingChars.Size = new System.Drawing.Size(376, 22);
               this.checkNoRepeatingChars.TabIndex = 0;
               this.checkNoRepeatingChars.Text = "&Each character must occur at most once";
               this.checkNoRepeatingChars.UseVisualStyleBackColor = true;
               this.checkNoRepeatingChars.CheckedChanged += new System.EventHandler(this.checkNoRepeatingChars_CheckedChanged);
               // 
               // checkExcludeLookAlike
               // 
               this.checkExcludeLookAlike.AutoSize = true;
               this.checkExcludeLookAlike.Location = new System.Drawing.Point(85, 89);
               this.checkExcludeLookAlike.Margin = new System.Windows.Forms.Padding(4);
               this.checkExcludeLookAlike.Name = "checkExcludeLookAlike";
               this.checkExcludeLookAlike.Size = new System.Drawing.Size(295, 22);
               this.checkExcludeLookAlike.TabIndex = 1;
               this.checkExcludeLookAlike.Text = "E&xclude look-alike characters";
               this.checkExcludeLookAlike.UseVisualStyleBackColor = true;
               this.checkExcludeLookAlike.CheckedChanged += new System.EventHandler(this.checkExcludeLookAlike_CheckedChanged);
               // 
               // checkExcludeChars
               // 
               this.checkExcludeChars.AutoSize = true;
               this.checkExcludeChars.Location = new System.Drawing.Point(85, 138);
               this.checkExcludeChars.Margin = new System.Windows.Forms.Padding(4);
               this.checkExcludeChars.Name = "checkExcludeChars";
               this.checkExcludeChars.Size = new System.Drawing.Size(259, 22);
               this.checkExcludeChars.TabIndex = 2;
               this.checkExcludeChars.Text = "Ex&clude these characters:";
               this.checkExcludeChars.UseVisualStyleBackColor = true;
               this.checkExcludeChars.CheckedChanged += new System.EventHandler(this.checkExcludeChars_CheckedChanged);
               // 
               // buttonCopy
               // 
               this.buttonCopy.Location = new System.Drawing.Point(605, 779);
               this.buttonCopy.Name = "buttonCopy";
               this.buttonCopy.Size = new System.Drawing.Size(180, 49);
               this.buttonCopy.TabIndex = 3;
               this.buttonCopy.Text = "&Copy";
               this.buttonCopy.UseVisualStyleBackColor = true;
               this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
               // 
               // formPasswordBuilder
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(1298, 859);
               this.Controls.Add(this.buttonCopy);
               this.Controls.Add(this.groupAdvancedOptions);
               this.Controls.Add(this.buttonOK);
               this.Controls.Add(this.buttonCancel);
               this.Controls.Add(this.groupGeneratePassword);
               this.Controls.Add(this.groupPasswordOptions);
               this.Margin = new System.Windows.Forms.Padding(4);
               this.Name = "formPasswordBuilder";
               this.Text = "Password Generator";
               ((System.ComponentModel.ISupportInitialize)(this.numericPasswordLength)).EndInit();
               this.groupPasswordOptions.ResumeLayout(false);
               this.groupPasswordOptions.PerformLayout();
               this.groupGeneratePassword.ResumeLayout(false);
               this.groupAdvancedOptions.ResumeLayout(false);
               this.groupAdvancedOptions.PerformLayout();
               this.ResumeLayout(false);

          }

          #endregion

          private void radioUsingNumeral_CheckedChanged(object sender, System.EventArgs args)
          {
               this.UpdateControlState();
               this.originalProfile.UsingAllNumeric = this.radioUsingNumeral.Checked;
          }

          private void radioUsingCharacter_CheckedChanged(object sender, System.EventArgs args)
          {
               this.UpdateControlState();
               this.originalProfile.UsingAllNumeric = !this.radioUsingCharacter.Checked;
          }

          private void buttonCancel_Click(object sender, System.EventArgs args)
          {
               this.DialogResult = DialogResult.Cancel;
          }

          private void buttonCopy_Click(object sender, System.EventArgs args)
          {
               var tmpPasswordString = this.textBoxPassword.Text;
               if (!string.IsNullOrEmpty(tmpPasswordString))
               {
                    if (tmpPasswordString.Contains(System.Environment.NewLine))
                    {
                         tmpPasswordString = tmpPasswordString.Replace(System.Environment.NewLine, string.Empty);
                    }

                    HuiruiSoft.Utils.ClipboardHelper.Copy(tmpPasswordString);
               }
          }

          private void buttonOK_Click(object sender, System.EventArgs args)
          {
               var tmpPasswordString = this.textBoxPassword.Text;
               if (!string.IsNullOrEmpty(tmpPasswordString))
               {
                    if (tmpPasswordString.Contains(System.Environment.NewLine))
                    {
                         tmpPasswordString = tmpPasswordString.Replace(System.Environment.NewLine, string.Empty);
                    }
               }

               this.PasswordString = tmpPasswordString;
               this.DialogResult = DialogResult.OK;
          }

          private void UpdateControlState()
          {
               if (this.blockUpdateControls)
               {
                    return;
               }

               this.blockUpdateControls = true;

               bool tmpUsingCharacter = this.radioUsingCharacter.Checked;
               this.checkUpperCase.Enabled = tmpUsingCharacter;
               this.checkLowerCase.Enabled = tmpUsingCharacter;
               this.checkDigitChars.Enabled = tmpUsingCharacter;
               this.checkMinusChar.Enabled = tmpUsingCharacter;
               this.checkUnderline.Enabled = tmpUsingCharacter;
               this.checkSpaceChar.Enabled = tmpUsingCharacter;
               this.checkSpecialChars.Enabled = tmpUsingCharacter;
               this.checkBracketChars.Enabled = tmpUsingCharacter;
               this.buttonOK.Enabled = this.buttonCopy.Enabled = !string.IsNullOrEmpty(this.textBoxPassword.Text);

               this.blockUpdateControls = false;
          }

          private void buttonGenerate_Click(object sender, System.EventArgs args)
          {
               this.textBoxPassword.Clear();

               var tmpPwdGenerator = new PasswordGenerator();
               tmpPwdGenerator.CharSet = new PasswordCharSet();
               if (this.radioUsingNumeral.Checked)
               {
                    tmpPwdGenerator.CharSet.Add(PasswordCharSet.DigitChars);
               }
               else
               {
                    if (this.checkUpperCase.Checked)
                    {
                         tmpPwdGenerator.CharSet.Add(PasswordCharSet.UpperChars);
                    }

                    if (this.checkLowerCase.Checked)
                    {
                         tmpPwdGenerator.CharSet.Add(PasswordCharSet.LowerChars);
                    }

                    if (this.checkDigitChars.Checked)
                    {
                         tmpPwdGenerator.CharSet.Add(PasswordCharSet.DigitChars);
                    }

                    if (this.checkMinusChar.Checked)
                    {
                         tmpPwdGenerator.CharSet.Add('-');
                    }

                    if (this.checkUnderline.Checked)
                    {
                         tmpPwdGenerator.CharSet.Add('_');
                    }

                    if (this.checkSpaceChar.Checked)
                    {
                         tmpPwdGenerator.CharSet.Add(' ');
                    }

                    if (this.checkSpecialChars.Checked)
                    {
                         tmpPwdGenerator.CharSet.Add(PasswordCharSet.SpecialChars);
                    }

                    if (this.checkBracketChars.Checked)
                    {
                         tmpPwdGenerator.CharSet.Add(PasswordCharSet.BracketChars);
                    }
               }

               tmpPwdGenerator.Length = (uint)this.numericPasswordLength.Value;
               tmpPwdGenerator.ExcludeLookAlike = this.checkExcludeLookAlike.Checked;
               tmpPwdGenerator.NoRepeatingChars = this.checkNoRepeatingChars.Checked;
               if (this.checkExcludeChars.Checked)
               {
                    tmpPwdGenerator.ExcludeCharacters = this.textExcludeChars.Text;
               }

               string tmpPassword = null;
               try
               {
                    tmpPassword = tmpPwdGenerator.GeneratePassword();
               }
               catch (TooFewCharacterException exception)
               {
                    loger.Error(exception);
                    this.numericPasswordLength.Focus();
                    MessageBox.Show(SafePassResource.PasswordGeneratorMessageCharSetTooFewChars, SafePassResource.MessageBoxCaptionInputError, MessageBoxButtons.OK, MessageBoxIcon.Error);
               }

               if (tmpPassword != null)
               {
                    var tmpFontFamily = this.textBoxPassword.Font.FontFamily;
                    float tmpFontSize, tmpLineSize;
                    if (tmpPassword.Length <= 16)
                    {
                         tmpFontSize = 36;
                    }
                    else if (tmpPassword.Length <= 20)
                    {
                         tmpFontSize = 32;
                    }
                    else if (tmpPassword.Length <= 30)
                    {
                         tmpFontSize = 20;
                         tmpLineSize = 8;
                         this.AppendRichText(this.textBoxPassword, System.Environment.NewLine, System.Drawing.Color.Empty, new System.Drawing.Font(tmpFontFamily, tmpLineSize));
                    }
                    else if (tmpPassword.Length <= 35)
                    {
                         tmpFontSize = 18;
                         tmpLineSize = 10;
                         this.AppendRichText(this.textBoxPassword, System.Environment.NewLine, System.Drawing.Color.Empty, new System.Drawing.Font(tmpFontFamily, tmpLineSize));
                    }
                    else if (tmpPassword.Length <= 50)
                    {
                         tmpFontSize = 22;
                    }
                    else if (tmpPassword.Length <= 80)
                    {
                         tmpFontSize = 18;
                    }
                    else
                    {
                         tmpFontSize = 14;
                    }

                    foreach (var item in tmpPassword)
                    {
                         if (char.IsNumber(item))
                         {
                              this.AppendRichText(this.textBoxPassword, string.Format("{0}", item), System.Drawing.Color.Blue, new System.Drawing.Font("Consolas", tmpFontSize));
                         }
                         else if (char.IsLetter(item))
                         {
                              this.AppendRichText(this.textBoxPassword, string.Format("{0}", item), System.Drawing.Color.Black, new System.Drawing.Font("Century", tmpFontSize));
                         }
                         else
                         {
                              this.AppendRichText(this.textBoxPassword, string.Format("{0}", item), System.Drawing.Color.OrangeRed, new System.Drawing.Font("Century", tmpFontSize));
                         }
                    }
               }

               this.UpdateControlState();
          }

          public void AppendRichText(RichTextBox richTextBox, string text, System.Drawing.Color color, System.Drawing.Font font)
          {
               richTextBox.SelectionStart = richTextBox.TextLength;
               richTextBox.SelectionLength = 0;
               richTextBox.SelectionFont = font;
               richTextBox.SelectionColor = color;
               richTextBox.AppendText(text);
               richTextBox.SelectionColor = richTextBox.ForeColor;
               richTextBox.SelectionAlignment = HorizontalAlignment.Center;
          }

          private void checkUpperCase_CheckedChanged(object sender, System.EventArgs args)
          {
               if (this.blockUpdateControls)
               {
                    return;
               }
               if (this.originalProfile != null)
               {
                    this.originalProfile.UsingUpperCase = this.checkUpperCase.Checked;
               }
          }

          private void checkLowerCase_CheckedChanged(object sender, System.EventArgs args)
          {
               if (this.blockUpdateControls)
               {
                    return;
               }
               if (this.originalProfile != null)
               {
                    this.originalProfile.UsingLowerCase = this.checkLowerCase.Checked;
               }
          }

          private void checkDigitChars_CheckedChanged(object sender, System.EventArgs args)
          {
               if (this.blockUpdateControls)
               {
                    return;
               }
               if (this.originalProfile != null)
               {
                    this.originalProfile.UsingDigitChars = this.checkDigitChars.Checked;
               }
          }

          private void checkSpaceChar_CheckedChanged(object sender, System.EventArgs args)
          {
               if (this.blockUpdateControls)
               {
                    return;
               }
               if (this.originalProfile != null)
               {
                    this.originalProfile.UsingSpaceChar = this.checkSpaceChar.Checked;
               }
          }

          private void checkMinusChar_CheckedChanged(object sender, System.EventArgs args)
          {
               if (this.blockUpdateControls)
               {
                    return;
               }
               if (this.originalProfile != null)
               {
                    this.originalProfile.UsingMinusChar = this.checkMinusChar.Checked;
               }
          }

          private void checkUnderline_CheckedChanged(object sender, System.EventArgs args)
          {
               if (this.blockUpdateControls)
               {
                    return;
               }
               if (this.originalProfile != null)
               {
                    this.originalProfile.UsingUnderline = this.checkUnderline.Checked;
               }
          }

          private void checkSpecialChars_CheckedChanged(object sender, System.EventArgs args)
          {
               if (this.blockUpdateControls)
               {
                    return;
               }
               if (this.originalProfile != null)
               {
                    this.originalProfile.UsingSpecialChars = this.checkSpecialChars.Checked;
               }
          }

          private void checkBracketChars_CheckedChanged(object sender, System.EventArgs args)
          {
               if (this.blockUpdateControls)
               {
                    return;
               }
               if (this.originalProfile != null)
               {
                    this.originalProfile.UsingBracketChars = this.checkBracketChars.Checked;
               }
          }

          private void numericPasswordLength_ValueChanged(object sender, System.EventArgs args)
          {
               if (this.blockUpdateControls)
               {
                    return;
               }
               if (this.originalProfile != null)
               {
                    this.originalProfile.Length = (uint)this.numericPasswordLength.Value;
               }
          }

          private void checkNoRepeatingChars_CheckedChanged(object sender, System.EventArgs args)
          {
               if (this.blockUpdateControls)
               {
                    return;
               }
               if (this.originalProfile != null)
               {
                    this.originalProfile.NoRepeatingChars = this.checkNoRepeatingChars.Checked;
               }
          }

          private void checkExcludeLookAlike_CheckedChanged(object sender, System.EventArgs args)
          {
               if (this.blockUpdateControls)
               {
                    return;
               }
               if (this.originalProfile != null)
               {
                    this.originalProfile.ExcludeLookAlike = this.checkExcludeLookAlike.Checked;
               }
          }

          private void textExcludeChars_TextChanged(object sender, System.EventArgs args)
          {
               if (this.blockUpdateControls)
               {
                    return;
               }
               if (this.originalProfile != null)
               {
                    this.originalProfile.ExcludeCharacters = this.textExcludeChars.Text;
               }
          }

          private void checkExcludeChars_CheckedChanged(object sender, System.EventArgs args)
          {
               if (this.blockUpdateControls)
               {
                    return;
               }
               if (this.originalProfile != null)
               {
                    if (!this.checkExcludeChars.Checked)
                    {
                         this.originalProfile.ExcludeCharacters = string.Empty;
                    }
                    else
                    {
                         this.originalProfile.ExcludeCharacters = this.textExcludeChars.Text;
                    }
               }
          }
     }
}
