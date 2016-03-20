package multiverse.mars.plugins;

import java.io.Serializable;

import multiverse.msgsys.Message;
import multiverse.msgsys.MessageTypeFilter;
import multiverse.server.engine.Engine;
import multiverse.server.engine.EnginePlugin;
import multiverse.server.engine.Hook;
import multiverse.server.engine.Namespace;
import multiverse.server.objects.Entity;
import multiverse.server.objects.EntityManager;
import multiverse.server.objects.Template;
import multiverse.server.plugins.WorldManagerClient.ExtensionMessage;
import multiverse.server.plugins.WorldManagerClient.TargetedExtensionMessage;
import multiverse.server.util.Log;
import multiverse.server.util.Logger;

public class UnitSwitcherPlugin extends EnginePlugin {
	public UnitSwitcher(){
		super("UnitSwitcher");
		setPluginType("UnitSwitcher");
	}
	
	public static final Logger log = new Logger("SwitcherPlugin");
	
    	
		//not sure if we need this
	 public void onActivate() {
        super.onActivate();
        //register message hooks
        registerHooks();
        //subscribe to training messages
        MessageTypeFilter filter = new MessageTypeFilter();
        filter.addType(TrainerClient.MSG_TYPE_SWITCH_CONTROLS);
        // filter.addType(TrainerClient.MSG_TYPE_REQ_SKILL_TRAINING);
        Engine.getAgent().createSubscription(filter, this);

        // this.registerPluginNamespace(Unit.NAMESPACE, new TrainerSubObjectHook());

        if (Log.loggingDebug)
            log.debug("UnitSwitcherPlugin activated");
    }
	
	protected void registerHooks() {
		getHookManager().addHook(UnitSwitcherClient.MSG_TYPE_SWITCH_CONTROLS, new SwitcherHook());
	}
	
	
	
    class SwitcherHook implements Hook {
        public bolean processMessage(Message msg, int flags) {
            
        }
    }
}

