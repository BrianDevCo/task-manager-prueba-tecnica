@echo off
echo ========================================
echo   SUBIR PROYECTO A GIT - TASK MANAGER
echo ========================================
echo.

REM Buscar Git en ubicaciones comunes
set "GIT_PATH="
set "GIT_CMD="

REM Verificar si Git está en PATH
where git >nul 2>nul
if %ERRORLEVEL% EQU 0 (
    set "GIT_CMD=git"
    goto found_git
)

REM Buscar Git en ubicaciones comunes
if exist "C:\Program Files\Git\bin\git.exe" (
    set "GIT_PATH=C:\Program Files\Git\bin"
    set "GIT_CMD=%GIT_PATH%\git.exe"
    goto found_git
)

if exist "C:\Program Files (x86)\Git\bin\git.exe" (
    set "GIT_PATH=C:\Program Files (x86)\Git\bin"
    set "GIT_CMD=%GIT_PATH%\git.exe"
    goto found_git
)

if exist "%LOCALAPPDATA%\Programs\Git\bin\git.exe" (
    set "GIT_PATH=%LOCALAPPDATA%\Programs\Git\bin"
    set "GIT_CMD=%GIT_PATH%\git.exe"
    goto found_git
)

REM Si no se encuentra Git
echo ERROR: Git no se encontró en el sistema
echo.
echo OPCIONES:
echo.
echo 1. INSTALAR GIT:
echo    - Descarga desde: https://git-scm.com/downloads
echo    - Durante la instalación, marca "Add Git to PATH"
echo    - Reinicia PowerShell después de instalar
echo.
echo 2. AGREGAR GIT AL PATH MANUALMENTE:
echo    - Busca dónde está instalado Git (generalmente en)
echo      C:\Program Files\Git\bin
echo    - Agrega esa ruta al PATH del sistema
echo    - Reinicia PowerShell
echo.
echo 3. USAR GIT BASH:
echo    - Si tienes Git instalado, busca "Git Bash" en el menú inicio
echo    - Abre Git Bash en esta carpeta
echo    - Ejecuta los comandos manualmente (ver INSTRUCCIONES_FINALES.txt)
echo.
echo 4. USAR RUTA COMPLETA:
echo    - Si Git está en otra ubicación, edita este script
echo    - Cambia la línea: set "GIT_CMD=git"
echo    - Por: set "GIT_CMD=C:\ruta\completa\a\git.exe"
echo.
echo Para más información, lee: SOLUCION_GIT_NO_EN_PATH.md
echo.
pause
exit /b 1

:found_git
echo [OK] Git encontrado: %GIT_CMD%
echo.

REM Agregar Git al PATH temporalmente para esta sesión
if not "%GIT_PATH%"=="" (
    set "PATH=%GIT_PATH%;%PATH%"
)

echo [1/5] Inicializando repositorio Git...
%GIT_CMD% init
if %ERRORLEVEL% NEQ 0 (
    echo ERROR al inicializar Git
    pause
    exit /b 1
)

echo.
echo [2/5] Agregando archivos...
%GIT_CMD% add .
if %ERRORLEVEL% NEQ 0 (
    echo ERROR al agregar archivos
    pause
    exit /b 1
)

echo.
echo [3/5] Haciendo commit inicial...
%GIT_CMD% commit -m "Initial commit: Task Manager Fullstack .NET - Prueba Tecnica"
if %ERRORLEVEL% NEQ 0 (
    echo ERROR al hacer commit
    echo.
    echo NOTA: Si es tu primer commit, necesitas configurar Git:
    echo   %GIT_CMD% config --global user.name "Tu Nombre"
    echo   %GIT_CMD% config --global user.email "tu@email.com"
    echo.
    echo Ejecuta estos comandos y vuelve a ejecutar este script.
    echo.
    pause
    exit /b 1
)

echo.
echo [4/5] Configurando rama main...
%GIT_CMD% branch -M main

echo.
echo ========================================
echo   ¡LISTO! Repositorio local creado
echo ========================================
echo.
echo Ahora necesitas:
echo.
echo 1. Crear un repositorio en GitHub:
echo    - Ve a: https://github.com
echo    - Click en "+" ^> "New repository"
echo    - Nombre: task-manager-prueba-tecnica
echo    - NO marques "Initialize with README"
echo    - Click en "Create repository"
echo.
echo 2. Conectar y subir (reemplaza TU_USUARIO):
echo    %GIT_CMD% remote add origin https://github.com/TU_USUARIO/task-manager-prueba-tecnica.git
echo    %GIT_CMD% push -u origin main
echo.
echo ========================================
pause
