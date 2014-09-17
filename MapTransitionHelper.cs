using UnityEngine;
using metaio;

namespace metaioPort {

	public class MapTransitionHelper {


	    // storing the last pose and attitude/orientation to update the pose while initializing.
		private bool m_last_camera_pose_valid;

		// to stay in the same cos, we need one cos offset (6DoF only, scale is not being considered for now).
		private TrackingValues m_offset_newCOS_from_oldCOS;
		private bool m_recompute_offset_after_next_initialized;
		
		private TrackingValues m_last_camera_pose;
		private SensorValues m_last_sensor_values;
	}
}
