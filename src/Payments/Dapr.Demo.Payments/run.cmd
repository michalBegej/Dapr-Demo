@REM Start docker - required

dapr run --app-id payments --app-port 5030 --dapr-http-port 5300 -- dotnet run