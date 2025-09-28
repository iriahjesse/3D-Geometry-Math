# 3D Geometry Task

A C\# and Unity project demonstrating the **re-implementation of core 3D geometry components**—Matrices, Quaternions, and Vector Operations—from fundamental linear algebra principles for virtual and augmented reality environments.

---

## Technical Overview & Core Implementations

This project required replicating the behavior of high-level Unity components using lower-level math, as covered in SL-3 (Virtual Reality Geometry). The implementation uses raw C\# and custom math classes, avoiding built-in Unity methods like `Quaternion.Euler` or `Matrix4x4.Rotate`.

### Section 1: Custom Rotations & Coordinate Systems

* **Custom Quaternion (`MyQuaternion.cs`):** Built a custom quaternion class from scratch, including implementation of the following core operations:
    * **Quaternion Multiplication** ($\mathbf{q}_3 = \mathbf{q}_1 \mathbf{q}_2$).
    * **Angle-Axis Conversion** ($\mathbf{q} = (\cos\frac{\theta}{2}, \mathbf{v} \sin\frac{\theta}{2})$).
    * **Inverse Quaternions** ($\mathbf{q}^{-1}$).
    * Used the result to transform the red cube via the formula: $\mathbf{p}' = \mathbf{q} \mathbf{p} \mathbf{q}^{-1}$.
* **Custom Matrix (`MyMatrix.cs`):** Built a custom matrix class to handle $3 \times 3$ rotation matrices, including:
    * **Matrix Multiplication** (`*` operator overloading).
    * Constructed Roll ($R_z$), Pitch ($R_x$), and Yaw ($R_y$) rotation matrices and applied them in the correct Euler order (Roll, then Pitch, then Yaw) to transform the blue cube.

### Section 2: Geometric Transformations

* **Custom Look-At Rotation (`MyLookAt.cs`):** Manually constructed the **$4 \times 4$ rotation matrix** required to make an object constantly "look at" a target. This involved:
    * Calculating the Look Vector $\mathbf{c} = \frac{\mathbf{p}-\mathbf{e}}{|\mathbf{p}-\mathbf{e}|}$.
    * Using **Cross Products** ($\mathbf{x} = \mathbf{u} \times \mathbf{z}$ and $\mathbf{z} \times \mathbf{x}$) to derive the three orthonormal column vectors of the $4 \times 4$ rotation matrix.
* **Vector Math for Visual Feedback (`FloorColor.cs`):** Implemented two critical vector analysis techniques:
    * **Radial Color Effect:** Calculated the **vector magnitude (distance)** between the player and floor tiles to create a proximity visualization.
    * **Directional Color Effect:** Used the **Dot Product** ($\mathbf{v'} \cdot \mathbf{f}$) to determine the collinearity between the player's forward vector and the tile's direction, providing directional feedback in the XZ-plane.

---

## Repository Contents

The repository contains the custom C\# solutions that replace standard Unity methods.

| File | Description |
| :--- | :--- |
| `MyMatrix.cs` | Custom $3 \times 3$ Matrix class, containing multiplication and rotation constructors. |
| `MyQuaternion.cs` | Custom Quaternion class, containing multiplication, inverse, and Angle-Axis conversion. |
| `MyLookAt.cs` | Logic for constructing the $4 \times 4$ rotation matrix used for the Look-At behavior. |
| `FloorColor.cs` | Logic for floor tile color manipulation using vector magnitude and dot products. |
| `README.md` | This document. |
| `LICENSE` | MIT License. |

---

## Project Demonstration

[**Direct Link to Solution Video**]
*(https://drive.google.com/file/d/1TpIPMgq4JIYpgQe5cd1y5TJf59r7-fd0/view?usp=sharing )*
