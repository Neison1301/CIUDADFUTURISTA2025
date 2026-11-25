# 🏙️ Ciudad Futurista 2050

**Tarea Académica 5 – Entorno futurista en Unity**

Curso: **Herramientas de Desarrollo Profesional TIC**
Docente: Jurado Sandoval, Jonathan Arturo
Lima – Perú · 2026

---

## 📥 Descargar APK (Android)

> **[⬇️ Descargar CiudadFuturista2050.apk](https://github.com/Neison1301/CIUDADFUTURISTA2025/releases/tag/v1.0)**

**Cómo instalarlo:**

1. Descarga el archivo `.apk` desde el enlace de arriba (sección *Releases* → *Assets*).
2. Cópialo al celular (o descárgalo directamente desde el celular).
3. Abre el archivo y, si Android lo pide, activa **"Instalar apps de orígenes desconocidos"**.
4. Instala y abre **Ciudad Futurista 2050**.

**Controles en el celular:**

| Gesto | Acción |
|---|---|
| Dedo en la mitad **izquierda** de la pantalla | Caminar |
| Dedo en la mitad **derecha** de la pantalla | Mirar alrededor |

---

## 📁 Estructura del proyecto

```
TA5_CiudadFuturista2050_EquipoXX/
├── Assets/
│   └── _TA5/
│       ├── Scenes/        # CiudadFuturista2050.unity
│       ├── Materials/     # Mat_Piso, Mat_AzulFuturista, Mat_GrisFuturista, Mat_Neon
│       ├── Scripts/
│       │   ├── JugadorMovil.cs          # Movimiento PC + táctil
│       │   └── Editor/ConstruirCiudad.cs # Genera la ciudad automáticamente
│       ├── Models/
│       ├── Prefabs/
│       ├── UI/
│       └── Tests/
├── Packages/
├── ProjectSettings/
└── README.md
```

> Las carpetas `Library/`, `Temp/`, `Logs/`, `UserSettings/`, etc. **no** se suben al repositorio (ver `.gitignore`); Unity las regenera al abrir el proyecto.

---

## ▶️ Cómo abrir el proyecto

1. Instala **Unity Hub** y el editor **Unity 6.3 LTS (6000.3.29f1)**.
   - Para generar el APK, agrega el módulo **Android Build Support**.
2. Clona el repositorio:
   ```bash
   git clone https://github.com/Neison1301/CIUDADFUTURISTA2025.git
   ```
3. En Unity Hub: **Add → Add project from disk** y selecciona la carpeta clonada.
4. Abre la escena `Assets/_TA5/Scenes/CiudadFuturista2050.unity`.
5. Si la ciudad no aparece, usa el menú **TA5 → Construir Ciudad**.

---

## 🎮 Modos de uso

### 💻 PC
- Activar el GameObject **Jugador** y desactivar **XR Origin**.
- **W A S D** para moverse y **mouse** para mirar.
- Requiere `Active Input Handler = Both` en *Project Settings → Player → Other Settings*.

### 🥽 HTC VIVE
- Activar **XR Origin (VR)** y desactivar **Jugador**.
- En *XR Plug-in Management* está activado **OpenXR** con el perfil **HTC Vive Controller Profile**.
- El `Piso_Ciudad` tiene **Teleportation Area**, por lo que se puede teletransportar entre el Portal, la Plaza y la Torre.

### 📱 Smartphone
- Activar **Jugador** y desactivar **XR Origin**.
- **File → Build Profiles → Android → Build** para generar el APK.
- Controles táctiles descritos arriba.

> ⚠️ **No usar las dos cámaras a la vez** (Jugador y XR Origin).

---

## 👥 Integrantes

- Huaripata García, Carlos Daniel
- Arzapalo Mantilla, Neison Ering
- Gabriel Canchanya, Daniel Jovani
