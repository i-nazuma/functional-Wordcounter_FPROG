@echo off
cls
echo "Please make sure to have dotnet installed on your machine and that you are in the project directory, otherwise, abort this script."
timeout 5
echo "Running Program.fs..."
dotnet run -- /samples .txt

echo "opening results..."
timeout 3
start result.csv
timeout 5