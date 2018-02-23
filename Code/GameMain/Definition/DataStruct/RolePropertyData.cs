namespace GameMain
{
    public class RolePropertyData
    {
        private RolePropertyType m_Type;
        private int m_Value;

        public RolePropertyData(RolePropertyType type, int value)
        {
            m_Type = type;
            m_Value = value;
        }

        public RolePropertyType Type
        {
            get
            {
                return m_Type;
            }
            set
            {
                m_Type = value;
            }
        }

        public int Value
        {
            get
            {
                return m_Value;
            }
            set
            {
                m_Value = value;
            }
        }

    }
}
