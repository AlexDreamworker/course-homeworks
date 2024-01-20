using System;
using System.Collections.Generic;

namespace Homework1.Task3 
{
    public class RaceChanger : IDisposable
    {
        private List<Detector> _detectors;

        public RaceChanger(List<Detector> detectors) 
        {
            _detectors = detectors;

            foreach (Detector detector in _detectors)
                detector.TriggerDetected += OnTriggerDetected;
        }
        
        public void Dispose()
        {
            foreach (Detector detector in _detectors)
                detector.TriggerDetected -= OnTriggerDetected;
        }

        private void OnTriggerDetected(RaceType newRaceType, IRace target) 
        {
            target.SetNewRace(newRaceType);
        }
    }
}