# Workshop: IBM Generative AI

## Overview
This hands-on will guide you through step-by-step on how to adopt IBM generative AI service/product (watsonx assistant, watsonx.ai and watson discovery) into your application with a simple use-case as starting point.

The sample app for this hands-on called TalkToDoc (ready to use) is a simple web application developed using .NET that enable user to chat with their document.

This sample app is powered by the following IBM generative AI service/product:

1. watsonx assistant: https://www.ibm.com/products/watsonx-assistant
2. watsonx.ai: https://www.ibm.com/products/watsonx-ai
3. watson discovery: https://www.ibm.com/products/watson-discovery

TalkToDoc architecture diagram:

<img src="assets/TalkToDocDiagram.png">

1. User upload a document
2. User start chat with the document
3. watsonx assistant query the docs
4. watsonx assistant send prompt (containing doc query results) to LLM to generate the answer

## Prerequisites
To be able to do this hans-on you will need to have the following:
1. IBM Cloud Account
2. Visual Studio Code: https://code.visualstudio.com/Download 
3. C# Dev Kit extension for VS Code: https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit
4. .NET SDK 8.0.2 - https://dotnet.microsoft.com/en-us/download/dotnet/8.0
5. Git Client: https://git-scm.com/
6. Clone hands-on assets from Github: https://github.com/ronikurnia1/TalkToDoc.git 

## Hands-on Guide

There are 3 parts of hands-on as following:
1. Provisioning IBM generative AI resources
2. Develop watsonx assistant
3. Integrate IBM generative AI capability into your app


## 1. Provisioning IBM generative AI resources

### 1.1. watsonx.ai

1. Login to https://cloud.ibm.com with your account
2. Click **Create resource** button at the right top corner
3. Type **Watson Machine Learning** into "Search the calatog..." textbox

    <img src="assets/Catalog.jpeg" width="390">
    
    then it will show like this:

    <img src="assets/watsonml.jpeg" width="390">

4. Select **Watson Machine Learning** as shown above, and then select a preferable location e.g. Tokyo(tj-tok) as shown below:

    <img src="assets/selectLocation.jpeg" width="280">

5. Under **Configure your resource** give the **Service name** as you prefer:

    <img src="assets/WatsonMachineLearning.jpeg" width="280">

6. Mark (check) that you have read and agree the license agreement

    <img src="assets/agree.jpeg" width="210">
    
    then click **Creat** button and wait for couple of minutes.

7. Click on **Launch in** --> **IBM watsonx** button
    
    <img src="assets/Launch.jpeg" width="350">

8. Select region/location your are using as you did on step-4 and login with your IBM Cloud Account by clicking **Continue** button

    <img src="assets/LoginCloudPakData.jpeg" width="300">

9. Create a new Project by clicking **+** button on the right side of the Projects tile

    <img src="assets/AddProject.jpeg" width="300">

10. Give it the project name and click **Create** button

    <img src="assets/NewProject.jpeg" width="300">

11. Get the Project ID by navigating to **Manage** tab. Take a note (copy and save) the Project ID, we will use it later.

    <img src="assets/ProjectId.jpeg" width="350">

12. Associate the Project with Watson Machine Learning you've just created in steps 2-6 by navigating to **Manage** tab --> **Service &amp; integrations**, and click **Associate service** button

    <img src="assets/AssociateProject.jpeg" width="450">

13. Select Machine Learning you've just created in steps 2-6 by marking it (check) and click **Associate** button

    <img src="assets/AssociateProjectDetail.jpeg" width="400">

14. Congratulation! now you've completed provision of watsonx.ai resource

### 1.2. watson discovery
1. Login to https://cloud.ibm.com with your account
2. Click **Create resource** button at the right top corner
3. Type **Watson Discovery** into "Search the calatog..." textbox

    <img src="assets/Catalog.jpeg" width="390">
    
    then it will show like this:

    <img src="assets/WatsonDiscovery.jpeg" width="390">

4. Select **Watson Discovery** as shown above, and then select a preferable location e.g. Tokyo(tj-tok) as shown below:

    <img src="assets/WatsonDiscoveryLocation.jpeg" width="280">

5. Under **Configure your resource** give the **Service name** as you prefer:

    <img src="assets/WatsonDiscoveryName.jpeg" width="280">

6. Mark (check) that you have read and agree the license agreement

    <img src="assets/agree.jpeg" width="210">
    
    then click **Creat** button and wait for couple of minutes.

7. Once Watson Discovery successfully created, take a note (copy and save) the **API key** and **URL** as we will need this later

    <img src="assets/WatsonDiscoveryApiKey.jpeg" width="330">


8. Open Watson Discovery by clicking **Launch Watson Discovery** button
    
    <img src="assets/LaunchWatsonDiscovery.jpeg" width="350">

9. Create a new Project by clicking **New project** button.

    <img src="assets/CreateNewProjectWD.jpeg" width="380">

10. Give it Project name, select **Document Retrieval** as for Project type and click **Next** button


    <img src="assets/CreateNewProjectDocumentRetrieval.jpeg" width="400">

11. Give it Collection name and leave English as selected language and then click **Finish** button

    <img src="assets/NewCollection.jpeg" width="300">

12. Get the Project ID by navigating to **Integrate and deploy** --> **API Information**. Take a note (copy and save) the Project ID as we will need this later

    <img src="assets/WatsonDiscoveryProjectId.jpeg" width="450">

13. Congratulation! now you've completed provision of Watson Discovery resource

### 1.3. watsonx assistant

1. Login to https://cloud.ibm.com with your account
2. Click **Create resource** button at the right top corner
3. Type **watsonx assistant** into "Search the calatog..." textbox

    <img src="assets/Catalog.jpeg" width="390">
    
    then it will show like this:

    <img src="assets/watsonxAssistant.jpeg" width="390">

4. Select **watsonx Assistant** as shown above, and then select a preferable location e.g. Tokyo(tj-tok) as shown below:

    <img src="assets/watsonxAssistantLocation.jpeg" width="280">

5. Under **Configure your resource** give the **Service name** as you prefer:

    <img src="assets/watsonxAssistantName.jpeg" width="280">

6. Mark (check) that you have read and agree the license agreement

    <img src="assets/agree.jpeg" width="210">
    
    then click **Creat** button and wait for couple of minutes.

7. Open watsonx Assistant by clicking **Launch watsonx Assistant** button

    <img src="assets/watsonxAssistantLaunch.jpeg" width="380">

8. Create your first assistant by following the screen wizard. Give it assistant a name, leave English as selected Assiatant language and click **Next** button

    <img src="assets/CreateAssistant.jpeg" width="400">

9. Personalize your assiatant by completing the wizard form and click **Next** button 

    <img src="assets/CreateAssistantPage2.jpeg" width="400">


10. Click **Next** button once more and finally click **Create** button.

11. Congratulation! now you've completed provision of watsonx Assistant resource


## 2. Develop watsonx Assistant

### 2.1. Setup Integration with Watson Discovery

### 2.2. Setup Integration with watsonx.ai

### 2.3 Upload pre-build watsonx Assistant

## 3. Integrate IBM generative AI capability into your app

### Clone source code

### Update application code

### Test your application



