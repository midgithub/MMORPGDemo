local m_VersionText
local m_NoticeButton
local m_AccountButton
local m_NoticePanel
local m_LoginPanel
local m_AccountInput
local m_PasswordInput
local m_RegisterButton
local m_LoginButton

function OnInit(userData)
	m_VersionText = self.UI:GetChild("tf_Version").asTextField;
	m_NoticeButton = self.UI:GetChild("btn_Notice").asButton;
	m_AccountButton = self.UI:GetChild("btn_Account").asButton;
	m_NoticePanel = self.UI:GetChild("notice").asCom;
	m_LoginPanel = self.UI:GetChild("login").asCom;
	m_AccountInput = m_LoginPanel:GetChild("ipt_account").asTextInput;
	m_PasswordInput = m_LoginPanel:GetChild("ipt_password").asTextInput;
	m_RegisterButton = m_LoginPanel:GetChild("btn_rigister").asButton;
	m_LoginButton = m_LoginPanel:GetChild("btn_login").asButton;

	m_NoticePanel.visible = false;
    m_LoginPanel.visible = false;

    m_NoticeButton.onClick:Add(
	    function()
	    	m_NoticePanel.visible = not m_NoticePanel.visible;
	    end)

    m_AccountButton.onClick:Add(
	    function()
	    	m_LoginPanel.visible = not m_LoginPanel.visible;
	    end)
end 

function OnOpen(userData)
    if userData == nil then

    	return
    end

    m_VersionText.text = userData.Version;
    m_LoginButton.onClick:Add(
	    function(obj)
	    	userData.OnClickLogin(obj)
	    end)

    m_RegisterButton.onClick:Add(  
    	function(obj)
	    	data.OnClickRegister(obj)
	    end)
end

function OnClose(userData)
	m_VersionText.text = string.Empty;
	
	m_NoticeButton.onClick:Clear();
	m_AccountButton.onClick:Clear();
    m_LoginButton.onClick:Clear();
    m_RegisterButton.onClick:Clear();
end

--function OnUpdate(elapseSeconds,realElapseSeconds)
	--print("LuaForm OnUpdate:"..elapseSeconds..":"..realElapseSeconds)
--end

--function OnDestroy()
--	print("LuaForm OnDestroy")
--end