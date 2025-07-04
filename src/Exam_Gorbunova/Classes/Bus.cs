namespace Exam_Gorbunova.Classes
{
    class Bus
    {
        private int _numberMarshrut { get; set; }
        private string _endStopedNumderOne { get; set; }
        private string _endStopedNumderTwo { get; set; }
        private int _countStoped { get; set; }


        public int NumberMarshrut
        { get => _numberMarshrut; set => _numberMarshrut = value; }

        public string EndStopedNumderOne
        { get => _endStopedNumderOne; set => _endStopedNumderOne = value; }
        public string EndStopedNumderTwo
        { get => _endStopedNumderTwo; set => _endStopedNumderTwo = value; }
        public int CountStoped
        { get => _countStoped; set => _countStoped = value; }
    }
}
