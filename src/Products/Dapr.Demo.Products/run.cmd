@REM Start docker - required

dapr run --app-id products --app-port 5010 --dapr-http-port 5100 --components-path ../../../components/ -- dotnet run