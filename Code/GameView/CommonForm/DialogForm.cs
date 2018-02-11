using FairyGUI;
using GameFramework;
using GameMain;
using UnityEngine;

namespace GameView
{
    public class DialogForm : FairyGuiForm
    {
        private Controller m_ModeController = null;
        private GTextField m_TitleText = null;
        private GTextField m_MessageText = null;
        private GButton m_ConfirmButton = null;
        private GButton m_CancelButton = null;
        private GButton m_OtherButton = null;

        private int m_DialogMode = 1;
        private bool m_PauseGame = false;
        private object m_UserData = null;
        private GameFrameworkAction<object> m_OnClickConfirm = null;
        private GameFrameworkAction<object> m_OnClickCancel = null;
        private GameFrameworkAction<object> m_OnClickOther = null;

        public int DialogMode
        {
            get
            {
                return m_DialogMode;
            }
        }

        public bool PauseGame
        {
            get
            {
                return m_PauseGame;
            }
        }

        public object UserData
        {
            get
            {
                return m_UserData;
            }
        }


        public void OnConfirmButtonClick()
        {
            Close();

            if (m_OnClickConfirm != null)
            {
                m_OnClickConfirm(m_UserData);
            }
        }

        public void OnCancelButtonClick()
        {
            Close();

            if (m_OnClickCancel != null)
            {
                m_OnClickCancel(m_UserData);
            }
        }

        public void OnOtherButtonClick()
        {
            Close();

            if (m_OnClickOther != null)
            {
                m_OnClickOther(m_UserData);
            }
        }

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            m_ModeController = window.GetController("dialogMode");
            m_TitleText = window.GetChild("Title").asTextField;
            m_MessageText = window.GetChild("Message").asTextField;
            m_ConfirmButton = window.GetChild("btn_confirm").asButton;
            m_CancelButton = window.GetChild("btn_cancel").asButton;
            m_OtherButton = window.GetChild("btn_other").asButton;
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            DialogParams dialogParams = (DialogParams)userData;
            if (dialogParams == null)
            {
                Log.Warning("DialogParams is invalid.");
                return;
            }

            m_DialogMode = dialogParams.Mode;
            RefreshDialogMode();

            m_TitleText.text = dialogParams.Title;
            m_MessageText.text = dialogParams.Message;

            m_PauseGame = dialogParams.PauseGame;
            RefreshPauseGame();

            m_UserData = dialogParams.UserData;

            RefreshConfirmText(dialogParams.ConfirmText);
            m_OnClickConfirm = dialogParams.OnClickConfirm;
            m_ConfirmButton.onClick.Add((obj) => m_OnClickConfirm.Invoke(obj));

            RefreshCancelText(dialogParams.CancelText);
            m_OnClickCancel = dialogParams.OnClickCancel;
            m_CancelButton.onClick.Add((obj) => m_OnClickCancel.Invoke(obj));

            RefreshOtherText(dialogParams.OtherText);
            m_OnClickOther = dialogParams.OnClickOther;
            m_OtherButton.onClick.Add((obj) => m_OnClickOther.Invoke(obj));
        }

        protected override void OnClose(object userData)
        {
            if (m_PauseGame)
            {
                GameEntry.Base.ResumeGame();
            }

            m_DialogMode = 1;
            m_TitleText.text = string.Empty;
            m_MessageText.text = string.Empty;
            m_PauseGame = false;
            m_UserData = null;

            RefreshConfirmText(string.Empty);
            m_OnClickConfirm = null;

            RefreshCancelText(string.Empty);
            m_OnClickCancel = null;

            RefreshOtherText(string.Empty);
            m_OnClickOther = null;

            base.OnClose(userData);
        }

        private void RefreshDialogMode()
        {
            m_ModeController.selectedIndex = m_DialogMode - 1;
        }

        private void RefreshPauseGame()
        {
            if (m_PauseGame)
            {
                GameEntry.Base.PauseGame();
            }
        }

        private void RefreshConfirmText(string confirmText)
        {
            if (string.IsNullOrEmpty(confirmText))
            {
                confirmText = GameEntry.Localization.GetString("Dialog.ConfirmButton");
            }

            m_ConfirmButton.title = confirmText;
        }

        private void RefreshCancelText(string cancelText)
        {
            if (string.IsNullOrEmpty(cancelText))
            {
                cancelText = GameEntry.Localization.GetString("Dialog.CancelButton");
            }

            m_CancelButton.title = cancelText;
        }

        private void RefreshOtherText(string otherText)
        {
            if (string.IsNullOrEmpty(otherText))
            {
                otherText = GameEntry.Localization.GetString("Dialog.OtherButton");
            }

            m_OtherButton.title = otherText;
        }

    }
}
