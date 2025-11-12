# 🔧 Solución: Git no está en PATH

## 📋 Problema

Git está instalado en tu computadora, pero PowerShell no lo encuentra porque no está en el PATH del sistema.

## ✅ Soluciones (elige la que prefieras)

### Opción 1: Agregar Git al PATH (Recomendada)

#### Paso 1: Encontrar dónde está Git

1. **Busca "Git" en el menú de inicio de Windows**
2. **Click derecho en "Git Bash"** → `Abrir ubicación del archivo`
3. **Click derecho en el acceso directo** → `Propiedades`
4. **Copia la ruta** que aparece en "Destino" (algo como: `C:\Program Files\Git\bin\bash.exe`)
5. **La carpeta de Git suele ser:** `C:\Program Files\Git\bin` (sin el `bash.exe`)

#### Paso 2: Agregar al PATH

**Método A: Desde la interfaz de Windows**

1. **Abre el Panel de Control**
2. **Ve a:** `Sistema` → `Configuración avanzada del sistema`
3. **Click en:** `Variables de entorno`
4. **En "Variables del sistema", busca:** `Path`
5. **Click en:** `Editar`
6. **Click en:** `Nuevo`
7. **Agrega la ruta:** `C:\Program Files\Git\bin` (o la ruta que encontraste)
8. **Click en:** `Aceptar` en todas las ventanas
9. **Reinicia PowerShell** o la terminal

**Método B: Desde PowerShell (como Administrador)**

```powershell
# Abre PowerShell como Administrador (Click derecho → Ejecutar como administrador)

# Agrega Git al PATH del sistema
$env:Path += ";C:\Program Files\Git\bin"

# O permanente:
[Environment]::SetEnvironmentVariable("Path", $env:Path + ";C:\Program Files\Git\bin", [EnvironmentVariableTarget]::Machine)

# Reinicia PowerShell
```

#### Paso 3: Verificar

```powershell
# Abre una nueva PowerShell y ejecuta:
git --version

# Debería mostrar: git version 2.x.x
```

---

### Opción 2: Usar Git Bash (Más fácil)

Si Git está instalado, **Git Bash** siempre funciona:

1. **Busca "Git Bash" en el menú de inicio**
2. **Click derecho** → `Abrir ubicación del archivo`
3. **Navega a la carpeta del proyecto:**
   ```bash
   cd /c/Entrevista/Proyecto/TaskManager
   ```
4. **Ejecuta los comandos:**
   ```bash
   git init
   git add .
   git commit -m "Initial commit: Task Manager Fullstack .NET - Prueba Tecnica"
   git branch -M main
   ```

---

### Opción 3: Usar la ruta completa de Git

Puedes usar Git sin agregarlo al PATH usando la ruta completa:

```powershell
# Reemplaza con la ruta real de tu Git
& "C:\Program Files\Git\bin\git.exe" init
& "C:\Program Files\Git\bin\git.exe" add .
& "C:\Program Files\Git\bin\git.exe" commit -m "Initial commit"
& "C:\Program Files\Git\bin\git.exe" branch -M main
```

**O crea un alias temporal:**

```powershell
# En PowerShell
Set-Alias -Name git -Value "C:\Program Files\Git\bin\git.exe"

# Ahora puedes usar git normalmente
git init
git add .
git commit -m "Initial commit"
```

---

### Opción 4: Reinstalar Git (si no está instalado)

1. **Descarga Git:** https://git-scm.com/downloads
2. **Ejecuta el instalador**
3. **Durante la instalación, asegúrate de marcar:**
   - ✅ "Add Git to PATH"
   - ✅ "Git from the command line and also from 3rd-party software"
4. **Completa la instalación**
5. **Reinicia PowerShell**
6. **Verifica:** `git --version`

---

### Opción 5: Usar el script actualizado

El script `SUBIR_A_GIT.bat` ahora busca Git automáticamente en ubicaciones comunes:

1. **Ejecuta:** `SUBIR_A_GIT.bat`
2. **El script buscará Git en:**
   - `C:\Program Files\Git\bin\git.exe`
   - `C:\Program Files (x86)\Git\bin\git.exe`
   - `%LOCALAPPDATA%\Programs\Git\bin\git.exe`
3. **Si lo encuentra, lo usará automáticamente**

---

## 🔍 Verificar si Git está instalado

### Método 1: Buscar en el menú de inicio
- Busca "Git" en el menú de inicio
- Si aparece "Git Bash" o "Git GUI", Git está instalado

### Método 2: Buscar archivos
- Abre el Explorador de archivos
- Busca: `git.exe`
- Si lo encuentras, anota la ruta completa

### Método 3: Desde PowerShell
```powershell
# Buscar Git en ubicaciones comunes
Test-Path "C:\Program Files\Git\bin\git.exe"
Test-Path "C:\Program Files (x86)\Git\bin\git.exe"
Test-Path "$env:LOCALAPPDATA\Programs\Git\bin\git.exe"
```

---

## 🚀 Después de solucionarlo

Una vez que Git funcione, ejecuta:

```powershell
cd C:\Entrevista\Proyecto\TaskManager
git init
git add .
git commit -m "Initial commit: Task Manager Fullstack .NET - Prueba Tecnica"
git branch -M main
```

Luego crea el repositorio en GitHub y conéctalo (ver `INSTRUCCIONES_FINALES.txt`).

---

## 💡 Recomendación

**La opción más fácil es usar Git Bash:**
- No requiere configuración
- Funciona inmediatamente
- Es la herramienta oficial de Git para Windows

---

## 📞 Si nada funciona

1. **Reinstala Git** desde: https://git-scm.com/downloads
2. **Durante la instalación, marca "Add Git to PATH"**
3. **Reinicia tu computadora**
4. **Vuelve a intentar**

---

**¡Éxito! 🚀**


