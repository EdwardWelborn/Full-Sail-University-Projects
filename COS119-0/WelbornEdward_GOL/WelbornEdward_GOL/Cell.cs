namespace WelbornEdward_GOL
{
    public struct Cell
    {
        public bool alive;

        public Cell(bool alive) => this.alive = alive;

        public bool Alive
        {
            get => this.alive;
            set => this.alive = value;
        }

        public bool Dead
        {
            get => !this.alive;
            set => this.alive = !value;
        }
    }
}