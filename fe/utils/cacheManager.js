const cacheStore = new Map();
const STALE_TIME = 300 * 1000; 

export const cacheManager = {
  get: (key) => {
    return cacheStore.get(key);
  },

  set: (key, data) => {
    cacheStore.set(key, {
      data,
      timestamp: Date.now(),
      promise: null 
    });
  },

  setPromise: (key, promise) => {
    const existing = cacheStore.get(key) || {};
    cacheStore.set(key, { ...existing, promise });
  },

  clearPromise: (key) => {
    const existing = cacheStore.get(key);
    if (existing) {
      cacheStore.set(key, { ...existing, promise: null });
    }
  },

  isStale: (key) => {
    const item = cacheStore.get(key);
    if (!item || !item.timestamp) return true;
    return Date.now() - item.timestamp > STALE_TIME;
  },

  invalidate: (keyPrefix) => {
    for (let key of cacheStore.keys()) {
      if (key.includes(keyPrefix)) {
        cacheStore.delete(key);
      }
    }
  }
};