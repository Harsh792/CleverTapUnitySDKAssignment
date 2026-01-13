# CleverTap Unity SDK Assignment

## Overview
This project is a submission for the CleverTap Unity SDK Developer assignment.

It consists of:
1. A reusable Unity Package (SDK) that exposes a GameObject to show a native Toast (Android) or Snackbar-style alert (iOS).
2. A Unity Weather App that captures the user's location, fetches weather data using a public API, and displays the result using the SDK.

---

## Unity Package (Toast / Snackbar SDK)

### Features
- Exposes a `ToastController` MonoBehaviour that can be attached to a GameObject
- Shows native Toast on Android
- Shows native alert (Snackbar-style) on iOS
- Clean platform abstraction using interfaces and factory pattern
- Safe fallback implementation for non-mobile platforms

### Package Structure

```text
Packages/com.harsh.toastlib/
├── Runtime/
│ ├── Harsh.ToastLib.Runtime.asmdef
│ ├── ToastController.cs
│ ├── IToastService.cs
│ ├── ToastFactory.cs
│ ├── AndroidToastService.cs
│ ├── IOSToastService.cs
│ └── DummyToastService.cs
├── Tests/
│ └── EditMode/
│     ├── Harsh.ToastLib.Tests.asmdef
│     └── ToastFactoryTests.cs
└── package.json
```


### Architecture
- `IToastService` defines the platform-independent interface
- Platform-specific implementations are selected using compile-time directives
- `ToastFactory` returns the correct implementation based on runtime platform
- `ToastController` acts as the public GameObject API for the SDK

This design ensures:
- Clear separation of concerns
- Easy extensibility
- SDK-style architecture suitable for reuse

---

## Weather App

### Features
- Captures user latitude and longitude using Unity Location Service
- Fetches weather data from Open-Meteo API
- Displays today's temperature using the Toast SDK
- Clean separation between UI, services, and data models

### Weather API
https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lon}&timezone=IST&daily=temperature_2m_max

The provided API returns daily maximum temperature, which is displayed in the app.

---

## How the SDK Is Used in the App
1. Import the Unity package
2. Add `ToastController` to a GameObject
3. Call `ShowToast(string message)` on user interaction
4. Weather app uses this SDK to display weather details


---


## Scenes
- **Main.unity**  
  Demonstrates the Toast/Snackbar Unity Package independently. Clicking the GameObject
  shows a native Toast (Android) or Snackbar-style alert (iOS).

- **WeatherScene.unity**  
  Main application scene that fetches user location, calls the Weather API, and displays
  weather information using the Toast SDK.


---


## Platform Notes
- Android uses native Toast via JNI
- iOS uses a native UIKit alert that auto-dismisses
- Location services and native functionality work only on device builds
- Unity Editor may log errors due to platform limitations (expected behavior)

---

## iOS Build Note
The iOS native functionality is implemented using Objective-C through Unity’s native plugin system.
Since development was done on a Windows machine, the iOS build could not be compiled or tested locally.
However, the implementation follows Unity’s recommended native plugin approach and can be built and tested on macOS using Xcode.


---

## Testing
- Unit tests are implemented using Unity Test Framework (EditMode)
- Tests validate factory creation and SDK initialization
- Bonus testing included as per assignment

---

## Build & Run
- Unity Version: 6000.3 LTS
- Tested on: Android device
- Build platform: Android / iOS

---


## Android Permissions
The application requires location access to fetch the user’s latitude and longitude.
The following permission is added in the custom Android manifest:

<uses-permission android:name="android.permission.ACCESS_FINE_LOCATION" />

Runtime permission is requested when the app is launched.


---


## Author
Harsh Bishnoi


