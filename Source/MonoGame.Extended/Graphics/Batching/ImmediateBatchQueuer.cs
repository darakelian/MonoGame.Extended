﻿using Microsoft.Xna.Framework.Graphics;

namespace MonoGame.Extended.Graphics.Batching
{
    internal class ImmediateBatchQueuer<TVertexType> : BatchQueuer<TVertexType>
        where TVertexType : struct, IVertexType
    {
        public ImmediateBatchQueuer(BatchDrawer<TVertexType> batchDrawer)
            : base(batchDrawer)
        {
        }

        internal override void Begin()
        {
        }

        internal override void End()
        {
        }

        internal override void EnqueueDraw(Effect effect, PrimitiveType primitiveType, TVertexType[] vertices, int startVertex, int vertexCount, uint sortKey = 0)
        {
            BatchDrawer.Select(vertices, startVertex, vertexCount);
            BatchDrawer.Draw(effect, primitiveType, startVertex, vertexCount);
        }

        internal override void EnqueueDraw(Effect effect, PrimitiveType primitiveType, TVertexType[] vertices, int startVertex, int vertexCount, short[] indices, int startIndex, int indexCount, uint sortKey = 0)
        {
            BatchDrawer.Select(vertices, startVertex, vertexCount, indices, startIndex, indexCount);
            BatchDrawer.Draw(effect, primitiveType, startVertex, startVertex + vertexCount, startIndex, indexCount);
        }
    }
}
