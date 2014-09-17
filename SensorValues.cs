using System;
using metaio;

namespace metaioPort
{
	
	/** Sensor reading with timestamp */
	struct SensorReading
	{ 
		public double timestamp;	//< timestamp (in seconds since system boot)
		public int accuracy;		//< accuracy - not yet really used (3 seems "good"...)
		public Vector3d values;	//< Three floating point numbers from a sensor.
		//< The interpretation depends on the sensor used.
		
		/** Default constructor */
		SensorReading(double timestamp = 0.0, int accuracy = 0)
		{
			this.timestamp = timestamp;
			this.accuracy = accuracy;
		}
		
		// Sensor readings should be sorted by timestamp
		public static bool operator <(SensorReading c1, SensorReading c2)
		{
			return c1.timestamp < c2.timestamp;
		}

		public static bool operator >(SensorReading c1, SensorReading c2)
		{
			return c1.timestamp > c2.timestamp;
		}
	};

	/** An encapsulation of all the sensors' readings with corresponding time stamps */
	public class SensorValues
	{
		public LLACoordinate location; //< Device location. Needed: SENSOR_LOCATION
		public Vector3d gravity; //< Normalized gravity vector. Needed: SENSOR_GRAVITY
		public double gravityTimestamp; //< timestamp (in seconds since system boot)
		public bool hasGravity() { 
			return gravityTimestamp > 0; 
		}

		public float heading; //< Heading in degrees, 0=North, 90=East, 180=South. Needed: SENSOR_HEADING
		public double headingTimestamp; //< timestamp (in seconds since system boot)
		public bool hasHeading() { 
			return headingTimestamp > 0; 
		}

		public Rotation attitude; //< device attitude based on running sensors. Needed: SENSOR_ATTITUDE
		public double attitudeTimestamp; //< timestamp (in seconds since system boot)
		public bool hasAttitude() { 
			return attitudeTimestamp > 0; 
		}

		public bool deviceIsMoving; //< Indicates if device is moving. Needed: SENSOR_DEVICE_MOVEMENT

		
		Vector<SensorReading> historicalGyroscopeVector;	///< Historical raw gyroscope values [rad/s] with timestamps in [s] Needed: SENSOR_DEVICE_GYROSCOPE
		stlcompat::Vector<SensorReading> historicalAccelerometerVector; ///< Historical raw accelerometer values [m/s^2] with timestamps in [s] Needed: SENSOR_DEVICE_ACCELEROMETER
		stlcompat::Vector<SensorReading> historicalMagnetometerVector; ///< Historical raw magnetometer values [microTesla] with timestamps [s] Needed: SENSOR_DEVICE_MAGNETOMETER

	}
}

