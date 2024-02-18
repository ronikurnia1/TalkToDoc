
## 3. Develop watsonx Assistant

This is the part 3 of 4 hands-on guides:
1. [Introduction](readme.md#1-introduction)
2. [Provisioning IBM generative AI resources](provisioning.md#2-provisioning-ibm-generative-ai-resources)
3. [Develop watsonx Assistant](develop.md#3-develop-watsonx-assistant)
4. [Integrate IBM generative AI to your app](integrate.md#4-integrate-ibm-generative-ai-to-your-app)

Part (part 3) will guide you how to setup watsonx Assistant using pre-build sample

### 2.1. Setup Integration with Watson Discovery

1. Open your watsonx Assistant (if you haven't done so) by logging in to https://cloud.ibm.com and navigate to **Resource list** --> **AI / Machine Learning** --> **[your watsonx Assistant name]** --> **Launch watsonx Assistant**

    <img src="assets/images/ResourceList.jpeg" width="350">

    <img src="assets/images/watsonxAssistantList.jpeg" width="260">

    <img src="assets/images/watsonxAssistantLaunch.jpeg" width="380">

2. Once your watsonx Assistant get opened, navigate to **Integrations** at the left side menu.

    <img src="assets/images/Integrations.png" width="300">

3. Scroll down little bit, under **Extensions** click **Build custom extension** button

    <img src="assets/images/BuildCustomExtension.jpeg" width="250">

4. On Custom extension, **Get Started** tab, click **Next** to move forward to Basic information tab.

    <img src="assets/images/CustomExtension1.jpeg" width="400">

5. On **Basic information** tab, give it Extension name e.g. *Watson Discovery* and then click **Next** button to move forward to Import OpenAPI tab

    <img src="assets/images/CustomExtension2.jpeg" width="400">

6. On **Import OpenAPI** tab, upload OpenAPI file of Watson Discovery that is located at **/assets/OpenAPI/watson-discovery-query-openapi.json** of the repo that you've cloned before and then click **Next** button to move forward to Review extension tab

    <img src="assets/images/CustomExtension4.jpeg" width="400">

7. On **Review extension** tab, click **Finish** button

    <img src="assets/images/CustomExtension5.jpeg" width="400">

8. Now, under **Extensions** you should see new tile available with the name you gave on step 5 e.g. *Watson Discovery*. Click **Add +** at the bottom right of the tile to add this extension into your watsonx Assistant **Draft environment**

    <img src="assets/images/WatsonDiscoveryExtension.jpeg" width="420">

9. Click **Add** button on the pop-up window and it will bring you to the extension authentication setting 

    <img src="assets/images/AddExtension.jpeg" width="350">

10. On the **Get started** tab, click **Next** button to move forward to the Authentication tab

    <img src="assets/images/AuthenticationExtension.jpeg" width="400">

11. On **Authentication** tab set the fields as follows:
    - Authentication type: **Basic auth**
    - Username: **apikey**
    - Password: **[ApiKey from 1.2. Watson Discovery step 7]**
    - discovery_url: **[Url from 1.2. Watson Discovery step 7]**

    <img src="assets/images/SettingAtuhExtension.jpeg" width="450">

    Click **Next** button to move forward to **Review operation** tab

12. On **Review operations** tab, click **Finish** button to complete the integration setup with Watson Discovery for Draft environment

13. The step 8 to 12 are the setup for Draft environment, now we need to setup the same for Live environment. To do that, under **Extensions** you should see the tile with the name you gave on step 5 e.g. *Watson Discovery*, click **Open** at the bottom right of the tile to add this extension into your watsonx Assistant **Live environment**

    <img src="assets/images/OpenForLive.jpeg" width="380">

14. On the pop-up window, change the Environment to **Live** and click **Confirm** button

    <img src="assets/images/ConfirmForLive.jpeg" width="350">

15. Repeat the step 10 to 12 above to complete the integration setup with Watson Discovery for Live environment

16. Congratulation! you've completed setup integration with Watson Discovery


### 2.2. Setup Integration with watsonx.ai

1. Open your watsonx Assistant (if you haven't done so) by logging in to https://cloud.ibm.com and navigate to **Resource list** --> **AI / Machine Learning** --> **[your watsonx Assistant name]** --> **Launch watsonx Assistant**

    <img src="assets/images/ResourceList.jpeg" width="350">

    <img src="assets/images/watsonxAssistantList.jpeg" width="260">

    <img src="assets/images/watsonxAssistantLaunch.jpeg" width="380">

2. Once your watsonx Assistant get opened, navigate to **Integrations** at the left side menu.

    <img src="assets/images/Integrations.png" width="300">

3. Scroll down little bit, under **Extensions** click **Build custom extension** button

    <img src="assets/images/BuildCustomExtension.jpeg" width="250">

4. On Custom extension, **Get Started** tab, click **Next** to move forward to Basic information tab.

    <img src="assets/images/CustomExtension1.jpeg" width="400">

5. On **Basic information** tab, give it Extension name e.g. *watsonx ai* and then click **Next** button to move forward to Import OpenAPI tab

    <img src="assets/images/watsonxAiCustomExtension.jpeg" width="400">

6. On **Import OpenAPI** tab, upload OpenAPI file of watsonx.ai that is located at **/assets/OpenAPI/watsonx-openapi.json** of the repo that you've cloned before and then click **Next** button to move forward to Review extension tab

    <img src="assets/images/watsonxAiCustomExtension2.jpeg" width="400">

7. On **Review extension** tab, click **Finish** button

    <img src="assets/images/CustomExtension5.jpeg" width="400">

8. Now, under **Extensions** you should see new tile available with the name you gave on step 5 e.g. *watsonx ai*. Click **Add +** at the bottom right of the tile to add this extension into your watsonx Assistant **Draft environment**

    <img src="assets/images/watsonxAiCustomExtension3.jpeg" width="420">

9. Click **Add** button on the pop-up window and it will bring you to the extension authentication setting 

    <img src="assets/images/Addwatsonxai.jpeg" width="350">

10. On the **Get started** tab, click **Next** button to move forward to the Authentication tab

    <img src="assets/images/AuthenticationExtension.jpeg" width="400">

11. On **Authentication** tab set the fields as follows:
    - Authentication type: **OAuth 2**
    - Grant type: **Custom apikey**
    - Apikey: **[ApiKey from 1.4. Create API key step 5]**
    - Leave the rest as is

    <img src="assets/images/watsonxAiAuth.jpeg" width="450">

    Click **Next** button to move forward to **Review operation** tab

12. On **Review operations** tab, click **Finish** button to complete the integration setup with watsonx.ai for Draft environment



13. The step 8 to 12 are the setup for Draft environment, now we need to setup the same for Live environment. To do that, under **Extensions** you should see the tile with the name you gave on step 5 e.g. *Watson ai*, click **Open** at the bottom right of the tile to add this extension into your watsonx Assistant **Live environment**

    <img src="assets/images/watsonxAiConfig.jpeg" width="420">

14. On the pop-up window, change the Environment to **Live** and click **Confirm** button

    <img src="assets/images/ConfirmForLive.jpeg" width="350">

15. Repeat step 10 to 12 above to complete the integration setup with watsonx.ai for Live environment

16. Congratulation! you've completed setup integration with watsonx.ai

### 2.3. Upload pre-build watsonx Assistant

1. Open watsonx Assistant (if you've not done so)
