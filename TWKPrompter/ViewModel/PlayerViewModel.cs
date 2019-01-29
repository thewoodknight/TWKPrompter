﻿using Stylet;
using System;
using System.Windows.Documents;
using TWKPrompter.Events;

namespace TWKPrompter.ViewModel
{
    public class PlayerViewModel : Screen
    {
        private double _scrollspeed = 20;
        public double ScrollSpeed
        {
            get { return _scrollspeed; }
            set
            {
                SetAndNotify(ref _scrollspeed, value);
            }
        }

        private double _scale = 2;
        public double Scale
        {
            get { return _scale; }
            set
            {
                SetAndNotify(ref _scale, value);
                NotifyOfPropertyChange(() => RenderOffsetScale);
            }
        }

        private int _mirror = -1;
        public int Mirror
        {
            get { return _mirror; }
            set
            {
                SetAndNotify(ref _mirror, value);
            }
        }

        private bool _playing = false;
        public bool Playing
        {
            get { return _playing; }
            set
            {
                SetAndNotify(ref _playing, value);
            }
        }


        public System.Windows.Point RenderOffsetScale
        {
            get { return new System.Windows.Point(_scale / 2, _scale / 2); }

        }

        private string _text = "";
        private readonly IEventAggregator eventAggregator;

        public string Text
        {
            get { return _text; }
            set
            {
                SetAndNotify(ref _text, value);
            }
        }

        public PlayerViewModel(IEventAggregator eventAggregator, String text)
        {
            this.eventAggregator = eventAggregator;
            Text = text;
        }

        public void MirrorFlip()
        {
            var x = (Mirror == -1) ? Mirror = 1 : Mirror = -1;
        }
        public void Smaller() { Scale -= 0.5; }
        public void Larger() { Scale += 0.5; }
        public void Slower() { ScrollSpeed -= 10; }
        public void Faster() { ScrollSpeed += 10; }

        public void PlayPause()
        {
            Playing = !Playing;
            eventAggregator.Publish(new PlayPauseEvent(Playing));
            Console.WriteLine(Playing);
        }

    }
}
