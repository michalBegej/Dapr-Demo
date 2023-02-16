# Dapr demo

Demo of [Dapr](https://docs.dapr.io/) used to communicate distributed dotnet application
<br/>
<br/>


# Dapr

## Links
- [Documentation](https://docs.dapr.io/)
- [Getting started](https://docs.dapr.io/getting-started/)
- [Github](https://github.com/dapr/dapr)
- [Github - dotnet sdk](https://github.com/dapr/dotnet-sdk)
- [ASP NetCore nuget](https://www.nuget.org/packages/Dapr.AspNetCore/1.10.0-rc03)

## Examples

### Run
```
dapr run --app-id [your-app-id] --app-port [your-app-port] -- dotnet run
```

### Invoke (CLI)
```
dapr invoke --app-id [your-app-id] --method [endpoint path] --verb [http-verb]
```

### Invoke (HTTP)
```
http://localhost:[dapr-port]/v1.0/invoke/[app-id]/method/[endpoint]
```
### Dashboard
```
dapr dashboard
```

# Tye

## Links
- [Documentation](https://github.com/dotnet/tye/tree/main/docs)
- [Getting started](https://github.com/dotnet/tye/blob/main/docs/getting_started.md)
- [GitHub](https://github.com/dotnet/tye)

## Examples

### Run
```
tye run
```





# Docker on Windows

Example of using docker on windows without docker desktop app

## Links

- [How to run docker on Windows without Docker Desktop](https://dev.to/_nicolas_louis_/how-to-run-docker-on-windows-without-docker-desktop-hik)

- [WSL instalation](https://learn.microsoft.com/en-us/windows/wsl/install-manual)

- [Instal Ubuntu on WSL2 on Windows 10](https://ubuntu.com/tutorials/install-ubuntu-on-wsl2-on-windows-10#1-overview)

- [VS code extension](https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-docker)


## Examples

Create `Start-docker.ps1 ` on local pc and setup path in Evn variables   

```ps
$currentPrincipal = New-Object Security.Principal.WindowsPrincipal([Security.Principal.WindowsIdentity]::GetCurrent())
if($false -eq $currentPrincipal.IsInRole([Security.Principal.WindowsBuiltInRole]::Administrator) ){
    Write-Host "Admin permission required!" -ForegroundColor Red
    Exit
}

$ip = (wsl sh -c "hostname -I").Split(" ")[0]
Write-Host "IP address mapped: $ip"
netsh interface portproxy add v4tov4 listenport=2375 connectport=2375 connectaddress=$ip
netsh interface portproxy add v4tov4 listenport=9200 connectport=9200 connectaddress=$ip
wsl sh -c "sudo dockerd -H tcp://$ip"
```

### Run

Open `Powershell` console as `Admin` and call `Start-docker.ps1 `
