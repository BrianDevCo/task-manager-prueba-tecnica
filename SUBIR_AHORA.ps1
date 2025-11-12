# Script rápido para subir a GitHub
Write-Host "========================================" -ForegroundColor Cyan
Write-Host "  SUBIR PROYECTO A GITHUB" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""

# Verificar estado
Write-Host "[1/4] Verificando estado del repositorio..." -ForegroundColor Yellow
git status --short
Write-Host ""

# Pedir información
Write-Host "Necesito la información de tu repositorio en GitHub:" -ForegroundColor White
Write-Host ""

$usuario = Read-Host "Tu usuario de GitHub (ej: brianl280499)"
$nombreRepo = Read-Host "Nombre del repositorio (ej: task-manager-prueba-tecnica)"

if ([string]::IsNullOrWhiteSpace($usuario) -or [string]::IsNullOrWhiteSpace($nombreRepo)) {
    Write-Host "[ERROR] Debes proporcionar usuario y nombre del repositorio" -ForegroundColor Red
    pause
    exit 1
}

$urlRepo = "https://github.com/$usuario/$nombreRepo.git"

Write-Host ""
Write-Host "[2/4] Conectando con GitHub..." -ForegroundColor Yellow
Write-Host "URL: $urlRepo" -ForegroundColor Gray

# Verificar si ya existe remote
$remoteExists = git remote get-url origin 2>&1
if ($LASTEXITCODE -eq 0) {
    Write-Host "[INFO] Ya existe un remote 'origin'" -ForegroundColor Yellow
    $cambiar = Read-Host "¿Deseas cambiarlo? (s/n)"
    if ($cambiar -eq "s" -or $cambiar -eq "S") {
        git remote set-url origin $urlRepo
        Write-Host "[OK] Remote actualizado" -ForegroundColor Green
    } else {
        Write-Host "[INFO] Usando remote existente" -ForegroundColor Yellow
        git remote -v
    }
} else {
    git remote add origin $urlRepo
    Write-Host "[OK] Remote agregado" -ForegroundColor Green
}

Write-Host ""
Write-Host "[3/4] Subiendo código a GitHub..." -ForegroundColor Yellow
Write-Host ""

# Intentar push
git push -u origin main

if ($LASTEXITCODE -eq 0) {
    Write-Host ""
    Write-Host "========================================" -ForegroundColor Green
    Write-Host "  ¡ÉXITO! Proyecto subido a GitHub" -ForegroundColor Green
    Write-Host "========================================" -ForegroundColor Green
    Write-Host ""
    Write-Host "Tu proyecto está disponible en:" -ForegroundColor White
    Write-Host "https://github.com/$usuario/$nombreRepo" -ForegroundColor Cyan
    Write-Host ""
} else {
    Write-Host ""
    Write-Host "[ERROR] No se pudo subir el proyecto" -ForegroundColor Red
    Write-Host ""
    Write-Host "Posibles causas:" -ForegroundColor Yellow
    Write-Host "1. El repositorio no existe en GitHub" -ForegroundColor White
    Write-Host "   - Crea el repositorio en: https://github.com/new" -ForegroundColor White
    Write-Host "   - NO marques 'Initialize with README'" -ForegroundColor White
    Write-Host ""
    Write-Host "2. Problemas de autenticación" -ForegroundColor White
    Write-Host "   - Necesitas un Personal Access Token" -ForegroundColor White
    Write-Host "   - Crea uno en: https://github.com/settings/tokens" -ForegroundColor White
    Write-Host "   - Permiso: 'repo'" -ForegroundColor White
    Write-Host ""
}

pause

