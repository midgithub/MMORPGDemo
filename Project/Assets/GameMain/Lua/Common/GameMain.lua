
--需要加载的模块--
local modules = {
	'Common/Define.lua'
}

--需要重载的模块（调式使用，发布更新时清空）
local reloads = {
	--'Common/Define.lua'
}

--先卸载重载模块--
for i,v in ipairs(reloads) do
	package.loaded[v] = nil
end

--加载所有模块--
for i,v in ipairs(modules) do
	if package.loaded[v] == nil then
		require(v)
	end
end


GameMain = {}

function GameMain.Entry()
 	Log.Info("Start Enter Lua")
 	--注册界面(id,lua路径，ui组件)
 	FairyGui:RegisterLuaForm(1003,"UIForm/LoginForm.lua")

end 

function GameMain.Update()
	--print("Lua OnUpdate")
end

function GameMain.LateUpdate()
	
end

function GameMain.FixedUpdate()

end

function GameMain.Exit()
	Log.Info("Lua Exit")
end