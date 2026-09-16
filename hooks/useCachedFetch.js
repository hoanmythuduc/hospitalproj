import { useState, useEffect, useCallback } from 'react';
import { dynamicApi } from '../api/api'; 
import { cacheManager } from '../utils/cacheManager';

export const useCachedFetch = (url) => {
  const [data, setData] = useState(null);
  const [isLoading, setIsLoading] = useState(true); 
  const [isFetching, setIsFetching] = useState(false); 
  const [error, setError] = useState(null);
  const fetchData = useCallback(async (forceRefetch = false) => {
    if (!url) return;
    const cacheKey = url;
    const cachedItem = cacheManager.get(cacheKey);
    if (cachedItem && cachedItem.data && !forceRefetch) {
      setData(cachedItem.data);
      setIsLoading(false); 

      if (!cacheManager.isStale(cacheKey)) {
        return; 
      }
    } else {
      setIsLoading(true);
    }

    try {
      setIsFetching(true);
      setError(null);
      
      let fetchPromise = cachedItem?.promise;

      if (!fetchPromise) {
        fetchPromise = dynamicApi.getAll(url);
        cacheManager.setPromise(cacheKey, fetchPromise);
      }

      const response = await fetchPromise;

      if (!response.error) {
        cacheManager.set(cacheKey, response); 
        setData(response);
      } else {
        setError(response.error);
      }
    } catch (err) {
      setError(err.message);
    } finally {
      cacheManager.clearPromise(cacheKey);
      setIsLoading(false);
      setIsFetching(false);
    }
  }, [url]);

  useEffect(() => {
    fetchData();
  }, [fetchData]);

  return { 
    data, 
    isLoading, 
    isFetching, 
    error, 
    refetch: () => fetchData(true) 
  };
};