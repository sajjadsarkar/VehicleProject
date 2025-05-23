# API Reference

This document provides a comprehensive reference for the main classes and methods available in the Unity-CSharp-Utilities package.

## Table of Contents

- [Extensions](#extensions)
- [Utility Class](#utility-class)
- [Data Serialization](#data-serialization)
- [Editor Utilities](#editor-utilities)
- [Math Structures](#math-structures)

## Extensions

Extensions enhance existing Unity and .NET types with additional functionality.

### Transform Extensions

| Method | Description |
|--------|-------------|
| `Find(string name, bool caseSensitive = true)` | Finds a direct child of the transform with the specified name |
| `FindStartsWith(string name, bool caseSensitive = true)` | Finds a direct child whose name starts with the specified string |
| `FindEndsWith(string name, bool caseSensitive = true)` | Finds a direct child whose name ends with the specified string |
| `FindContains(string name, bool caseSensitive = true)` | Finds a direct child whose name contains the specified string |
| `FindInChildren(string name, bool caseSensitive = true)` | Recursively searches for a child with the specified name |
| `FindComponentInChildren<T>(bool includeInactive = false)` | Finds a component of type T in the children |

### AnimationCurve Extensions

| Method | Description |
|--------|-------------|
| `Clamp01(this AnimationCurve curve)` | Clamps all keyframes to the range [0,1] for both time and value |
| `Clamp(this AnimationCurve curve, Keyframe min, Keyframe max)` | Clamps all keyframes to the range defined by min and max keyframes |
| `Clamp(this AnimationCurve curve, float timeMin, float timeMax, float valueMin, float valueMax)` | Clamps all keyframes to the specified ranges |
| `Clone(this AnimationCurve curve)` | Creates a deep copy of the animation curve |

### String Extensions

| Method | Description |
|--------|-------------|
| `IsNullOrEmpty(this string str)` | Checks if a string is null or empty |
| `IsNullOrWhiteSpace(this string str)` | Checks if a string is null, empty, or contains only whitespace |
| `Join(this string[] strings, string separator)` | Joins an array of strings with the specified separator |
| `Join(this List<string> strings, string separator)` | Joins a list of strings with the specified separator |

## Utility Class

The `Utility` class provides a broad range of utility functions that are not specific to any particular type.

### Math Functions

| Method | Description |
|--------|-------------|
| `Average(params float[] values)` | Calculates the average of the provided values |
| `Average(params Vector2[] vectors)` | Calculates the average of the provided Vector2 values |
| `Average(params Vector3[] vectors)` | Calculates the average of the provided Vector3 values |
| `Distance(Transform a, Transform b)` | Calculates the distance between two transforms |
| `Direction(Vector3 from, Vector3 to)` | Returns the normalized direction from one point to another |
| `Lerp(float a, float b, float t)` | Linearly interpolates between a and b by t (clamped) |
| `InverseLerp(float a, float b, float value)` | The opposite of Lerp; returns the t value given a result |

### Color Utilities

| Method | Description |
|--------|-------------|
| `HexToColor(string hex)` | Converts a hex color string to a Color |
| `ColorToHex(Color color, bool includeAlpha = false)` | Converts a Color to a hex string |
| `Lighten(Color color, float amount)` | Lightens a color by the specified amount |
| `Darken(Color color, float amount)` | Darkens a color by the specified amount |

### Array & Collection Utilities

| Method | Description |
|--------|-------------|
| `Shuffle<T>(this T[] array)` | Randomly shuffles the elements in an array |
| `Shuffle<T>(this List<T> list)` | Randomly shuffles the elements in a list |
| `RandomElement<T>(this T[] array)` | Returns a random element from an array |
| `RandomElement<T>(this List<T> list)` | Returns a random element from a list |

## Data Serialization

### DataSerializationUtility<T>

Utility class for serializing and deserializing data to and from files.

| Method | Description |
|--------|-------------|
| `SaveOrCreate(T data)` | Saves data to a file at the specified path |
| `Load()` | Loads and deserializes data from a file at the specified path |
| `Delete()` | Deletes the file at the specified path |
| `Exists()` | Checks if the file exists at the specified path |

#### Constructor Parameters

| Parameter | Description |
|-----------|-------------|
| `path` | The path to save and load the data |
| `useResources` | Whether to load the data from Unity's Resources system |
| `bypassExceptions` | Whether to return default values instead of throwing errors |

## Editor Utilities

### EditorUtilities

Utility class for editor-related functions.

| Method | Description |
|--------|-------------|
| `AddScriptingDefineSymbol(string symbol)` | Adds a scripting define symbol to all build targets |
| `RemoveScriptingDefineSymbol(string symbol)` | Removes a scripting define symbol from all build targets |
| `ScriptingDefineSymbolExists(string symbol)` | Checks if a scripting define symbol exists |
| `GetProjectPath()` | Returns the absolute path to the project folder |
| `GetSelectionPath()` | Returns the path of the first selected item in the Project window |

### ScriptableObjectUtility

Utility class for working with ScriptableObjects in the editor.

| Method | Description |
|--------|-------------|
| `CreateAsset<T>() where T : ScriptableObject` | Creates a new ScriptableObject asset |
| `CreateAsset<T>(string path) where T : ScriptableObject` | Creates a ScriptableObject asset at the specified path |
| `FindAssetsByType<T>() where T : UnityEngine.Object` | Finds all assets of a specific type |

## Math Structures

### Interval

Represents a closed interval [min, max] of floating-point values.

| Property/Method | Description |
|-----------------|-------------|
| `Min` | The minimum value of the interval |
| `Max` | The maximum value of the interval |
| `Size` | The size of the interval (max - min) |
| `Middle` | The middle value of the interval ((min + max) / 2) |
| `Lerp(float t)` | Linearly interpolates between min and max by t |
| `InverseLerp(float value)` | Returns the normalized position of value within the interval |
| `Clamp(float value)` | Clamps a value to the interval |
| `InRange(float value)` | Checks if a value is within the interval |

### Interval2

Represents a 2D interval with X and Y components.

| Property/Method | Description |
|-----------------|-------------|
| `X` | The X interval component |
| `Y` | The Y interval component |
| `Size` | The size of the interval as a Vector2 |
| `Center` | The center of the interval as a Vector2 |
| `Contains(Vector2 point)` | Checks if a point is within the 2D interval |
| `Lerp(float t)` | Linearly interpolates between min and max by t (same t for both dimensions) |
| `Lerp(Vector2 t)` | Linearly interpolates between min and max using separate t values for each dimension |

### Interval3

Represents a 3D interval with X, Y, and Z components.

| Property/Method | Description |
|-----------------|-------------|
| `X` | The X interval component |
| `Y` | The Y interval component |
| `Z` | The Z interval component |
| `Size` | The size of the interval as a Vector3 |
| `Center` | The center of the interval as a Vector3 |
| `Contains(Vector3 point)` | Checks if a point is within the 3D interval |
| `Lerp(float t)` | Linearly interpolates between min and max by t (same t for all dimensions) |
| `Lerp(Vector3 t)` | Linearly interpolates between min and max using separate t values for each dimension |
