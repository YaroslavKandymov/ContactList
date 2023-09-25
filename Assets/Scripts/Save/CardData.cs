using System;

namespace ContactList.Save
{
    [Serializable]
    public struct CardData
    {
        public int Id { get; private set; }
        public bool IsFavorite { get; set; }
        public byte[] Texture { get; private set; }

        public CardData(int id, bool isFavorite, byte[] texture)
        {
            Id = id;
            IsFavorite = isFavorite;
            Texture = texture;
        }
    }
}