using FairyGUI;
using GameFramework;

namespace GameMain
{
    public class LoginForm : FairyGuiForm
    {
        private GTextField m_VersionText = null;
        private GButton m_NoticeButton = null;
        private GButton m_AccountButton = null;
        private GComponent m_NoticePanel = null;
        private GComponent m_LoginPanel = null;
        private GTextInput m_AccountInput = null;
        private GTextInput m_PasswordInput = null;
        private GButton m_RegisterButton = null;
        private GButton m_LoginButton = null;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            m_VersionText = UI.GetChild("tf_Version").asTextField;
            m_NoticeButton = UI.GetChild("btn_Notice").asButton;
            m_AccountButton = UI.GetChild("btn_Account").asButton;
            m_NoticePanel = UI.GetChild("notice").asCom;
            m_LoginPanel = UI.GetChild("login").asCom;
            m_AccountInput = m_LoginPanel.GetChild("ipt_account").asTextInput;
            m_PasswordInput = m_LoginPanel.GetChild("ipt_password").asTextInput;
            m_RegisterButton = m_LoginPanel.GetChild("btn_rigister").asButton;
            m_LoginButton = m_LoginPanel.GetChild("btn_login").asButton;

            m_NoticePanel.visible = false;
            m_LoginPanel.visible = false;

            m_NoticeButton.onClick.Add(() =>
            {
                m_NoticePanel.visible = !m_NoticePanel.visible;
            });
            m_AccountButton.onClick.Add(() =>
            {
                m_LoginPanel.visible = !m_LoginPanel.visible;
            });
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            LoginFormParams data = (LoginFormParams)userData;
            if (data == null)
            {
                Log.Warning("LoginFormParams is invalid.");
                return;
            }

            m_VersionText.text = data.Version;
            m_LoginButton.onClick.Add(obj => data.OnClickLogin(obj));
            m_RegisterButton.onClick.Add(obj => data.OnClickRegister(obj));
        }

        protected override void OnClose(object userData)
        {
            base.OnClose(userData);

            m_VersionText.text = string.Empty;
            m_LoginButton.onClick.Clear();
            m_RegisterButton.onClick.Clear();
        }

    }
}
