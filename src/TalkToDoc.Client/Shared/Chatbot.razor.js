let webChatInstance;
export async function showChatbot(integrationId, region, serviceInstanceId) {
	window.watsonAssistantChatOptions = {
		integrationID: integrationId,
		region: region,
		serviceInstanceID: serviceInstanceId,
		showRestartButton: true,
		onLoad: async (instance) => {
			webChatInstance = instance;
			await webChatInstance.render();
		}
	};

	var t = document.getElementById("watsonx-chatbot");
	if (t != null) {
		document.removeChild(t);
	}
	t = document.createElement('script');
	t.id = "watsonx-chatbot";
	t.src = "https://web-chat.global.assistant.watson.appdomain.cloud/versions/latest/WatsonAssistantChatEntry.js";
	document.body.appendChild(t);

	setTimeout(function () {
		webChatInstance?.changeView('mainWindow').then(function () { webChatInstance?.closeWindow(); });
	});
}

export async function destroyChatbot() {
	webChatInstance?.destroy();
}

