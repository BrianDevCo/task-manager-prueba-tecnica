# Script para subir el proyecto a GitHub
# Ejecuta este script después de crear el repositorio en GitHub

Write-Host "========================================" -ForegroundColor Cyan
Write-Host "  SUBIR PROYECTO A GITHUB" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""

# Agregar Git al PATH si no está
$gitPath = "C:\Program Files\Microsoft Visual Studio\18\Community\Common7\IDE\CommonExtensions\Microsoft\TeamFoundation\Team Explorer\Git\cmd"
if (Test-Path "$gitPath\git.exe") {
    $env:Path += ";$gitPath"
    Write-Host "[OK] Git encontrado y agregado al PATH" -ForegroundColor Green
} else {
    Write-Host "[ERROR] Git no encontrado en la ubicación esperada" -ForegroundColor Red
    Write-Host "Por favor, verifica que Git esté instalado" -ForegroundColor Yellow
    pause
    exit 1
}

# Verificar que estamos en un repositorio Git
$gitStatus = git status 2>&1
if ($LASTEXITCODE -ne 0) {
    Write-Host "[ERROR] No se encontró un repositorio Git" -ForegroundColor Red
    Write-Host "Ejecuta primero: git init" -ForegroundColor Yellow
    pause
    exit 1
}

Write-Host ""
Write-Host "========================================" -ForegroundColor Cyan
Write-Host "  PASO 1: Verificar estado del repositorio" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""

git status

Write-Host ""
Write-Host "========================================" -ForegroundColor Cyan
Write-Host "  PASO 2: Conectar con GitHub" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""

# Verificar si ya existe un remote
$remoteExists = git remote get-url origin 2>&1
if ($LASTEXITCODE -eq 0) {
    Write-Host "[INFO] Ya existe un remote 'origin':" -ForegroundColor Yellow
    git remote -v
    Write-Host ""
    $cambiar = Read-Host "¿Deseas cambiar la URL del remote? (s/n)"
    if ($cambiar -eq "s" -or $cambiar -eq "S") {
        $url = Read-Host "Ingresa la URL del repositorio (ej: https://github.com/USUARIO/REPO.git)"
        git remote set-url origin $url
        Write-Host "[OK] Remote actualizado" -ForegroundColor Green
    }
} else {
    Write-Host "Necesitas crear un repositorio en GitHub primero:" -ForegroundColor Yellow
    Write-Host ""
    Write-Host "1. Ve a: https://github.com" -ForegroundColor White
    Write-Host "2. Click en '+' > 'New repository'" -ForegroundColor White
    Write-Host "3. Nombre: task-manager-prueba-tecnica (o el que prefieras)" -ForegroundColor White
    Write-Host "4. NO marques 'Initialize with README'" -ForegroundColor White
    Write-Host "5. Click en 'Create repository'" -ForegroundColor White
    Write-Host ""
    
    $url = Read-Host "Ingresa la URL del repositorio (ej: https://github.com/USUARIO/REPO.git)"
    
    if ($url) {
        git remote add origin $url
        Write-Host "[OK] Remote agregado: $url" -ForegroundColor Green
    } else {
        Write-Host "[ERROR] URL no proporcionada" -ForegroundColor Red
        pause
        exit 1
    }
}

Write-Host ""
Write-Host "========================================" -ForegroundColor Cyan
Write-Host "  PASO 3: Subir a GitHub" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""

Write-Host "Subiendo código a GitHub..." -ForegroundColor Yellow
Write-Host ""

# Intentar hacer push
git push -u origin main

if ($LASTEXITCODE -eq 0) {
    Write-Host ""
    Write-Host "========================================" -ForegroundColor Green
    Write-Host "  ¡ÉXITO! Proyecto subido a GitHub" -ForegroundColor Green
    Write-Host "========================================" -ForegroundColor Green
    Write-Host ""
    Write-Host "Tu proyecto está disponible en:" -ForegroundColor White
    git remote get-url origin
    Write-Host ""
} else {
    Write-Host ""
    Write-Host "[ERROR] No se pudo subir el proyecto" -ForegroundColor Red
    Write-Host ""
    Write-Host "Posibles causas:" -ForegroundColor Yellow
    Write-Host "1. Problemas de autenticación" -ForegroundColor White
    Write-Host "   - GitHub ya no acepta contraseñas" -ForegroundColor White
    Write-Host "   - Necesitas un Personal Access Token" -ForegroundColor White
    Write-Host "   - Crea uno en: https://github.com/settings/tokens" -ForegroundColor White
    Write-Host "   - Selecciona el permiso 'repo'" -ForegroundColor White
    Write-Host ""
    Write-Host "2. El repositorio no existe o la URL es incorrecta" -ForegroundColor White
    Write-Host ""
    Write-Host "3. Ya existe contenido en el repositorio remoto" -ForegroundColor White
    Write-Host "   - Si es así, usa: git pull origin main --allow-unrelated-histories" -ForegroundColor White
    Write-Host "   - Luego: git push -u origin main" -ForegroundColor White
    Write-Host ""
}

Write-Host ""
pause

