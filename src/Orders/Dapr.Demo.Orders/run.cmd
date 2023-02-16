@REM Start docker - required

dapr run --app-id orders --app-port 5020 --dapr-http-port 5200 --components-path ../../../components/ -- dotnet run