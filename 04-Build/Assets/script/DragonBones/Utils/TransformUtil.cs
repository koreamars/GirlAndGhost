// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;
using Com.Viperstudio.Geom;
using Com.Viperstudio.Utils;
using DragonBones.Objects;

namespace DragonBones.Utils
{
	public class TransformUtil
	{
		private const float HALF_PI = (float)Math.PI * 0.5f;
		private const float DOUBLE_PI = (float)Math.PI * 2f;
		
		private static Com.Viperstudio.Geom.Matrix _helpMatrix = new Com.Viperstudio.Geom.Matrix();
		
		public static void TransformPointWithParent(DBTransform transform, DBTransform parent)
		{
			TransformToMatrix(parent, _helpMatrix);

			_helpMatrix.Invert();

			float x = transform.X;
		    float y = transform.Y;
			
			transform.X = _helpMatrix.A * x + _helpMatrix.C * y + _helpMatrix.Tx;
			transform.Y = _helpMatrix.D * y + _helpMatrix.B * x + _helpMatrix.Ty;
			
			transform.SkewX = FormatRadian(transform.SkewX - parent.SkewX);
			transform.SkewY = FormatRadian(transform.SkewY - parent.SkewY);
		}
		
		public static void TransformToMatrix(DBTransform transform, Com.Viperstudio.Geom.Matrix matrix)
		{
			matrix.A = transform.ScaleX * (float)Math.Cos (transform.SkewY);
			matrix.B = transform.ScaleX * (float)Math.Sin (transform.SkewY);
			matrix.C = -transform.ScaleY * (float)Math.Sin(transform.SkewX);
			matrix.D = transform.ScaleY * (float)Math.Cos(transform.SkewX);
			matrix.Tx = transform.X;
			matrix.Ty = transform.Y;
		}
		
		public static float FormatRadian(float radian)
		{
			radian %= DOUBLE_PI;
			if (radian > Math.PI)
			{
				radian -= DOUBLE_PI;
			}
			if (radian < -Math.PI)
			{
				radian += DOUBLE_PI;
			}
			return radian;
		}
	}
}

