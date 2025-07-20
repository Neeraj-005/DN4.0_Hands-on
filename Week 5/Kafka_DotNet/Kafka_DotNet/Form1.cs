using Confluent.Kafka; 
using System;
using System.Text;
using System.Threading; 
using System.Threading.Tasks; 
using System.Windows.Forms; 

namespace Kafka_DotNet
{
    public partial class Form1 : Form
    {

        private IProducer<Null, string> _producer;

        private string _kafkaTopic = "chat-message"; 
        private string _kafkaBroker = "localhost:9092"; 

        public Form1()
        {
            InitializeComponent();

            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var producerConfig = new ProducerConfig { BootstrapServers = _kafkaBroker };

            _producer = new ProducerBuilder<Null, string>(producerConfig).Build();

        }

        private void Send_Click(object sender, EventArgs e)
        {
            string messageText = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(messageText))
            {
                MessageBox.Show("Please Enter a Message", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            _producer.Produce(_kafkaTopic, new Message<Null, string> { Value = messageText },
                deliveryReport =>
                {
                    if (deliveryReport.Error.Code != ErrorCode.NoError)
                    {
                        Console.WriteLine($"Failed to deliver message: {deliveryReport.Error.Reason}");
                    }
                    else
                    {
                        Console.WriteLine($"Delivered message to: {deliveryReport.TopicPartitionOffset}");
                    }
                });

            textBox1.Clear();
            textBox1.Focus();
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            _producer?.Dispose();
        }


        private void Cancel_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Focus();
        }


    }
}