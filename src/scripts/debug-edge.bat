@echo off

echo Starting Edge for debugging:
echo host: https://localhost:5001/

"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe" --remote-debugging-port=9222 --user-data-dir="C:\Users\georg\AppData\Local\Temp\blazor-edge-debug" --no-first-run https://localhost:5001/