package multiverse.mars.plugins;

import java.util.*;
import java.io.Serializable;
import multiverse.msgsys.*;
import multiverse.server.util.*;
import multiverse.server.engine.*;
import multiverse.server.network.MVByteBuffer;
import multiverse.mars.core.*;

//client for sending/ getting messages for the SwitcherPlugin


public class UnitSwitcherClient {
    private UnitSwitcherClient(){
    }
    
    public static void switchClients(Long oid, Long targetOid, boolean status){
        SwitchMessage = new SwitchMessage(oid, targetOid, status);
		Engine.getAgent().sendBroadcast(msg);
    }
	
	public SwitchMessage extends SubjectMessage
	{
		public SwitchMessage(){
			super();
		}
		
		public SwitchMessage(MessageType type) {
            super(type);
        }
		
		public SwitchMessage(MessageType type, Long oid, Long targetOid){
			super(type, oid);
			setTargetOid(targetOid);
		}
		
		public Long getTargetOid() {
            return this.targetOid;
        }

        public void setTargetOid(Long oid) {
            this.targetOid = oid;
        }
		
	}
}