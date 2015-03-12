﻿/*
 * This code is a partially modified version of the code found here: http://stackoverflow.com/questions/6560493/messagebox-show-custom-icon
 * The author (Brian Graham) claims it can be used without copy-right as seen in the second comment on his answer.

 * If the author of this code wishes I do not use it in this application, simply send me an email at radfordhound@gmail.com telling me so with
 * some proof that you are, in fact, the author, and I'll remove it from this program as soon as possible.
*/

using System;
using System.Drawing;
using System.Windows.Forms;

namespace LGM
{
    public static class CustomMessageBox
    {
        public static DialogResult Show(string Text, string Title, eDialogButtons Buttons, Image Image)
        {
            MessageForm message = new MessageForm();
            message.Text = Title;

            if (Image.Height < 0 || Image.Height > 64)
                throw new Exception("Invalid image height. Valid height ranges from 0 to 64.");
            else if (Image.Width < 0 || Image.Width > 64)
                throw new Exception("Invalid image width. Valid width ranges from 0 to 64.");
            else
            {

                message.picImage.Image = Image;
                message.lblText.Text = Text;

                switch (Buttons)
                {
                    case eDialogButtons.OK:
                        message.btnYes.Visible = false;
                        message.btnNo.Visible = false;
                        message.btnCancel.Visible = false;
                        message.btnOK.Location = message.btnCancel.Location;
                        message.AcceptButton = message.btnOK;
                        MessageForm.error = false;
                        break;
                    case eDialogButtons.OKCancel:
                        message.btnYes.Visible = false;
                        message.btnNo.Visible = false;
                        message.AcceptButton = message.btnOK;
                        MessageForm.error = false;
                        break;
                    case eDialogButtons.YesNo:
                        message.btnOK.Visible = false;
                        message.btnCancel.Visible = false;
                        message.btnYes.Location = message.btnOK.Location;
                        message.btnNo.Location = message.btnCancel.Location;
                        message.AcceptButton = message.btnYes;
                        MessageForm.error = false;
                        break;
                    case eDialogButtons.YesNoCancel:
                        message.btnOK.Visible = false;
                        message.AcceptButton = message.btnYes;
                        MessageForm.error = false;
                        break;
                    case eDialogButtons.ErrorBtn:
                        message.btnYes.Visible = false;
                        message.btnNo.Visible = false;
                        message.btnCancel.Visible = false;
                        message.btnOK.Location = message.btnCancel.Location;
                        message.AcceptButton = message.btnOK;
                        MessageForm.error = true;
                        break;
                }

                if (message.lblText.Height > 64)
                    message.Height = (message.lblText.Top + message.lblText.Height) + 78;

                return (message.ShowDialog());
            }
        }

        public enum eDialogButtons
        {
            OK,
            OKCancel,
            YesNo,
            YesNoCancel,
            ErrorBtn,
        }
    }
}