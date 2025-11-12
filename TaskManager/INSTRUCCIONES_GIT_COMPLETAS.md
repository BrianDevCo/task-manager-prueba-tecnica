# 🚀 Guía Completa: Subir Proyecto a GitHub

## ✅ Estado Actual

Tu proyecto **ya está inicializado con Git** y tiene el commit inicial realizado:
- ✅ Repositorio Git inicializado
- ✅ Archivos agregados al staging
- ✅ Commit inicial creado
- ✅ Rama `main` configurada
- ✅ `.gitignore` configurado para .NET

## 📋 Próximos Pasos

### Paso 1: Crear Repositorio en GitHub

1. Ve a [GitHub](https://github.com) e inicia sesión
2. Click en el botón **"+"** (arriba derecha)
3. Selecciona **"New repository"**
4. Configura el repositorio:
   - **Nombre**: `task-manager-prueba-tecnica` (o el que prefieras)
   - **Descripción**: "Aplicación fullstack .NET 8 para gestión de tareas - Prueba Técnica"
   - **Visibilidad**: Public o Private (tu elección)
   - ⚠️ **NO marques** "Initialize with README" (ya tienes uno)
   - ⚠️ **NO marques** "Add .gitignore" (ya tienes uno)
5. Click en **"Create repository"**

### Paso 2: Conectar y Subir

Tienes **3 opciones**:

#### Opción A: Script Automático (Recomendado) ⭐

1. **Ejecuta el script de PowerShell:**
   ```powershell
   .\SUBIR_A_GITHUB.ps1
   ```
2. El script te guiará paso a paso
3. Ingresa la URL de tu repositorio cuando te la pida

#### Opción B: Comandos Manuales

Abre PowerShell en la carpeta `TaskManager` y ejecuta:

```powershell
# 1. Agregar Git al PATH (solo la primera vez)
$env:Path += ";C:\Program Files\Microsoft Visual Studio\18\Community\Common7\IDE\CommonExtensions\Microsoft\TeamFoundation\Team Explorer\Git\cmd"

# 2. Conectar con GitHub (reemplaza TU_USUARIO y NOMBRE_REPO)
git remote add origin https://github.com/TU_USUARIO/NOMBRE_REPO.git

# 3. Subir el código
git push -u origin main
```

#### Opción C: Usar Git Bash

Si prefieres usar Git Bash (siempre funciona):

1. Busca **"Git Bash"** en el menú de inicio
2. Navega a la carpeta:
   ```bash
   cd /c/Entrevista/Proyecto/TaskManager
   ```
3. Ejecuta:
   ```bash
   git remote add origin https://github.com/TU_USUARIO/NOMBRE_REPO.git
   git push -u origin main
   ```

### Paso 3: Autenticación

Si GitHub te pide autenticación:

⚠️ **GitHub ya NO acepta contraseñas**, necesitas un **Personal Access Token**:

1. Ve a: https://github.com/settings/tokens
2. Click en **"Generate new token"** > **"Generate new token (classic)"**
3. Configura el token:
   - **Note**: "Task Manager Project"
   - **Expiration**: Elige una fecha (o "No expiration")
   - **Scopes**: Marca **"repo"** (acceso completo a repositorios)
4. Click en **"Generate token"**
5. **Copia el token** (solo se muestra una vez)
6. Cuando Git te pida la contraseña, **pega el token** en su lugar

### Paso 4: Verificar

1. Refresca la página de tu repositorio en GitHub
2. Deberías ver todos tus archivos
3. El `README.md` debería aparecer formateado

## 🔧 Solución de Problemas

### Error: "remote origin already exists"

Si ya existe un remote, puedes:
- **Ver el remote actual:**
  ```powershell
  git remote -v
  ```
- **Cambiar la URL:**
  ```powershell
  git remote set-url origin https://github.com/NUEVO_USUARIO/NUEVO_REPO.git
  ```
- **Eliminar y volver a agregar:**
  ```powershell
  git remote remove origin
  git remote add origin https://github.com/USUARIO/REPO.git
  ```

### Error: "failed to push some refs"

Si el repositorio remoto tiene contenido (por ejemplo, un README):

```powershell
# Traer cambios remotos
git pull origin main --allow-unrelated-histories

# Resolver conflictos si los hay, luego:
git push -u origin main
```

### Error: "authentication failed"

1. Verifica que estés usando un **Personal Access Token**, no tu contraseña
2. Asegúrate de que el token tenga el permiso **"repo"**
3. Si usas HTTPS, puedes configurar Git Credential Manager:
   ```powershell
   git config --global credential.helper manager-core
   ```

### Git no está en PATH

Si Git no funciona en PowerShell, usa una de estas opciones:

1. **Agregar Git al PATH permanentemente:**
   - Busca "Variables de entorno" en Windows
   - Agrega: `C:\Program Files\Microsoft Visual Studio\18\Community\Common7\IDE\CommonExtensions\Microsoft\TeamFoundation\Team Explorer\Git\cmd`
   - Reinicia PowerShell

2. **Usar Git Bash** (siempre funciona)

3. **Usar la ruta completa:**
   ```powershell
   & "C:\Program Files\Microsoft Visual Studio\18\Community\Common7\IDE\CommonExtensions\Microsoft\TeamFoundation\Team Explorer\Git\cmd\git.exe" push -u origin main
   ```

## 📝 Comandos Útiles

```powershell
# Ver estado del repositorio
git status

# Ver commits
git log --oneline

# Ver remotes configurados
git remote -v

# Ver ramas
git branch -a

# Agregar cambios nuevos
git add .
git commit -m "Descripción del cambio"
git push

# Ver diferencias
git diff
```

## 🎉 ¡Listo!

Una vez que subas el proyecto, podrás:
- Ver tu código en GitHub
- Compartir el repositorio
- Colaborar con otros desarrolladores
- Hacer deploy automático (si configuras CI/CD)

---

**¿Necesitas ayuda?** Revisa los archivos:
- `SOLUCION_GIT_NO_EN_PATH.md` - Si Git no funciona
- `COMANDOS_GIT_BASH.txt` - Comandos para Git Bash
- `SUBIR_A_GIT.bat` - Script batch alternativo

