# Try Out Development Containers: .NET Core

This is a sample project that lets you try out the **[VS Code Remote - Containers](https://aka.ms/vscode-remote/containers)** extension in a few easy steps.

> **Note:** If you're following the quick start, you can jump to the [Things to try](#things-to-try) section. 

## Setting up the development container

Follow these steps to open this sample in a container:

1. If this is your first time using a development container, please follow the [getting started steps](https://aka.ms/vscode-remote/containers/getting-started).

2. To use this repository, you can either open the repository in an isolated Docker volume:

    - Press <kbd>F1</kbd> and select the **Remote-Containers: Try a Sample...** command.
    - Choose the ".NET Core" sample, wait for the container to start and try things out!
        > **Note:** Under the hood, this will use **Remote-Containers: Open Repository in Container...** command to clone the source code in a Docker volume instead of the local filesystem.

   Or open a locally cloned copy of the code:

   - Clone this repository to your local filesystem.
   - Press <kbd>F1</kbd> and select the **Remote-Containers: Open Folder in Container...** command.
   - Select the cloned copy of this folder, wait for the container to start, and try things out!

3. If you want to enable **HTTPS**, see [enabling HTTPS](#enabling-https) to reuse your local development cert in the container.

## Things to try

One you have this sample opened in a container, you'll be able to work with it like you would locally.

> **Note:** This container runs as a non-root user with sudo access by default. Comment out `"remoteUser": "vscode"` in `.devcontainer/devcontainer.json` if you'd prefer to run as root.

Some things to try:

1. **Restore Packages:** When notified by the C# extension to install packages, click Restore to trigger the process from inside the container!

2. **Edit:**
   - Open `Program.cs`
   - Try adding some code and check out the language features.

3. **Terminal:** Press <kbd>ctrl</kbd>+<kbd>shift</kbd>+<kbd>\`</kbd> and type `dotnet --version` and other Linux commands from the terminal window.

4. **Build, Run, and Debug:**
   - Open `Program.cs`
   - Add a breakpoint (e.g. on line 21).
   - Press <kbd>F5</kbd> to launch the app in the container.
   - Once the breakpoint is hit, try hovering over variables, examining locals, and more.
   - Continue, then open a local browser and go to `http://localhost:5000` and note you can connect to the server in the container.

5. **Forward another port:**
   - Stop debugging and remove the breakpoint.
   - Open `appsettings.Development.json`
   - Update `"Url": "http://localhost:5000"` to `"Url": "http://localhost:9000"`.
   - Press <kbd>F5</kbd> to launch the app in the container.
   - Press <kbd>F1</kbd> and run the **Forward a Port** command.
   - Select port 9000.
   - Click "Open Browser" in the notification that appears to access the web app on this new port.

### Enabling HTTPS

To enable HTTPS for this sample, you can mount an exported copy of a locally generated dev certificate. Note that these instructions assume you already have the `dotnet` CLI installed on your local operating system.

1. Enable HTTPS in the sample by updating the `env` property in `.vscode/launch.json` as follows:

   ```json
   "env": {
         "ASPNETCORE_ENVIRONMENT": "HttpsDevelopment"
   }
   ```

2. Next, export the SSL cert using the following command:

    **Windows PowerShell**

    ```powershell
    dotnet dev-certs https --trust; dotnet dev-certs https -ep "$env:USERPROFILE/.aspnet/https/aspnetapp.pfx" -p "SecurePwdGoesHere"
    ```

    **macOS/Linux terminal**

    ```powershell
    dotnet dev-certs https --trust; dotnet dev-certs https -ep "${HOME}/.aspnet/https/aspnetapp.pfx" -p "SecurePwdGoesHere"
    ```

3. Add the following in to `.devcontainer/devcontainer.json`:

    ```json
    "remoteEnv": {
        "ASPNETCORE_Kestrel__Certificates__Default__Password": "SecurePwdGoesHere",
        "ASPNETCORE_Kestrel__Certificates__Default__Path": "/home/vscode/.aspnet/https/aspnetapp.pfx",
    }
    ```

4. Finally, make the certificate available in the container as follows:

    **If using GitHub Codespaces and/or Remote - Containers**

    1. Start the container/codespace
    2. Drag `~/.aspnet/https/aspnetapp.pfx` from your local machine into the root of the File Explorer in VS Code.
    3. Open a terminal in VS Code and run:
        ```bash
        mkdir -p /home/vscode/.aspnet/https && mv aspnetapp.pfx /home/vscode/.aspnet/https
        ```

    **If using only Remote - Containers with a local container**

    Add the following to `.devcontainer/devcontainer.json`:

    ```json
    "mounts": [ "source=${env:HOME}${env:USERPROFILE}/.aspnet/https,target=/home/vscode/.aspnet/https,type=bind" ]
    ```

5. If you've already opened your folder in a container, rebuild the container using the **Remote-Containers: Rebuild Container** command from the Command Palette (<kbd>F1</kbd>) so the settings take effect.

Next time you debug using VS Code (<kbd>F5</kbd>), you'll be able to use HTTPS! Note that you will need to specifically navigate to `https://localhost:5001` to get the certificate to work (**not** `https://127.0.0.1:5001`).

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a
Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us
the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide
a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions
provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or
contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

## License

Copyright © Microsoft Corporation All rights reserved.<br />
Licensed under the MIT License. See LICENSE in the project root for license information.
