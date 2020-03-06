FROM microsoft/dotnet:2.2-sdk

WORKDIR /app
COPY . .

ENTRYPOINT [ "dotnet", "run", "--urls", "http://0.0.0.0:5000" ]
