# serverless-csharp-hipchat
Template for HipChat bot Serverless service using C#

# Prerequisites

- AWS account
  - The services used by this example *should* be free, but you're responsible for grokking AWS pricing
- Serverless: `npm i -g serverless` or `yarn global add serverless`
  - You'll need to configure your installation with your AWS credentials: `serverless config credentials --provider aws --key <ACCESS_KEY> --secret <SECRET_KEY>`
  - See here for more details: https://serverless.com/framework/docs/providers/aws/guide/credentials/
- `dotnet` CLI tools: https://www.microsoft.com/net/core

# Getting Started

## Deploying the service

1. Install this service: `serverless install -u https://github.com/FLGMwt/serverless-csharp-hipchat`
  - Note that this creates a directory named `serverless-csharp-hipchat`. I'd recommend renaming that to whatever makes sense for you
2. `cd serverless-csharp-hipchat`
3. Run the build script for your system: `./build.sh` or `./build.ps1`
4. Deploy your app: `sls deploy`

## Adding your HipChat integration

1. In the HipChat console, find the page for the room you want to add your integration to
  - Note that you must own the room or be a HipChat admin for the installation
2. Click "Integrations"
3. Click "Build Your Own Integration" (first box in the grid)
4. Name it whatever you please
5. Click "Create"
6. Check "Add a command"
7. For the "slash command" enter how you want your integration to be invoked, e.g. "/officemap"
8. For the integration url, enter the POST endpoint route listed under `endpoints` during your `sls deploy`, e.g. "https://asdfzxcvfoobar.execute-api.us-east-1.amazonaws.com/dev/hello"
  - You can also get this output outside of deploys using `serverless info`
9. Click "Save"
10. In your room, test out your slash command.

# Troubleshooting

- If your slash command doesn't respond, you can try looking at the serverless logs: `serverless logs -f <your_function_name>`

# Tips

- `serverless` is aliased as `sls`. `sls deploy` is easier to write than `serverless deploy`
 - Note this gets clobbered by PowerShell's `sls` alias for `Select-String`. If you want `sls` to be the `serverless` alias, add the following to your `$PROFILE`: `rm Alias:\sls`
