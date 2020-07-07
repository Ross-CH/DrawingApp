using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//static void CovertToWorldSpace(ref Mesh originalMesh, Transform meshTransform)
//{
//	Vector3[] newVertices = new Vector3[originalMesh.vertexCount];
//	Vector3[] newNormals = new Vector3[originalMesh.vertexCount];
//	Vector4[] newTangents = new Vector4[originalMesh.vertexCount];
//	for (int i = 0; i < originalMesh.vertexCount; i++)
//	{
//		newVertices[i] = meshTransform.TransformPoint(originalMesh.vertices[i]);
//		newNormals[i] = meshTransform.TransformVector(originalMesh.normals[i]);
//		newTangents[i] = meshTransform.TransformVector(originalMesh.tangents[i]);
//	}
//	originalMesh.vertices = newVertices;
//	originalMesh.normals = newNormals;
//	originalMesh.tangents = newTangents;
//}