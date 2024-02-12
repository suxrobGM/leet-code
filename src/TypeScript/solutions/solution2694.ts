type Callback = (...args: any[]) => any;
type Subscription = {
  unsubscribe: () => void;
}

/**
 * 2694. Event Emitter
 * 
 * {@link https://leetcode.com/problems/event-emitter See more}
 */
class EventEmitter {
  private readonly events = new Map<string, Callback[]>();

  subscribe(eventName: string, callback: Callback): Subscription {
    if (!this.events.has(eventName)) {
      this.events.set(eventName, []);
    }

    this.events.get(eventName)!.push(callback);

    return {
      unsubscribe: () => {
        const idx = this.events.get(eventName)!.indexOf(callback);
        if (idx !== -1) {
          this.events.get(eventName)!.splice(idx, 1);
        }
      }
    };
  }
  
  emit(eventName: string, args: any[] = []): any[] {
    if (!this.events.has(eventName)) {
      return [];
    }

    return this.events.get(eventName)!.map((callback) => callback(...args));
  }
}
