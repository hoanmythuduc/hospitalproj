export const parseMatrixToTreeAndIds = (matrixNodes) => {
  const menuMap = {};
  const actionMap = {};
  const flatIds = new Set();

  const buildRecursively = (currentNodes, currentParentLabel) => {
    return currentNodes.map(node => {
      menuMap[node.id] = { ...node, parentLabel: currentParentLabel };
      
      if (node.isGranted) flatIds.add(`MENU|${node.id}`);

      const uiChildren = [];
      if (node.children && node.children.length > 0) {
        uiChildren.push(...buildRecursively(node.children, node.label));
      }

      if (node.action && Array.isArray(node.action)) {
        const actionNodes = node.action.map(act => {
          actionMap[act.id] = { ...act, menuId: node.id };
          
          if (act.isGranted) flatIds.add(`ACTION|${act.id}`);

          return {
            id: `ACTION|${act.id}`,
            label: act.label, 
            isAction: true
          };
        });
        uiChildren.push(...actionNodes);
      }

      return {
        id: `MENU|${node.id}`,
        label: node.label,
        icon: node.icon,
        children: uiChildren
      };
    });
  };

  const uiTree = buildRecursively(matrixNodes, null);

  ////////
  // console.log(`menuMap: ${JSON.stringify(menuMap)}`);
  // console.log(`actionMap: ${JSON.stringify(actionMap)}`);
  // console.log(`uiTree: ${JSON.stringify(uiTree)}`);
  // console.log(`initialFlatIds: ${JSON.stringify(Array.from(flatIds))}`);
  //////

  return { menuMap, actionMap, uiTree, initialFlatIds: Array.from(flatIds) };
};

export const buildPayloadFromFlatIds = (flatIds, menuMap, actionMap) => {
  const payloadMap = {};

  const initMenuInPayload = (mId) => {
    if (!payloadMap[mId] && menuMap[mId]) {
      payloadMap[mId] = {
        menuId: parseInt(mId, 10),
        menuLabel: menuMap[mId].label,
        parentLabel: menuMap[mId].parentLabel || null,
        action: []
      };
    }
  };

  flatIds.forEach(idStr => {
    const [type, key] = idStr.split('|');
    if (type === 'MENU') {
      initMenuInPayload(key);
    } else if (type === 'ACTION') {
      const actDef = actionMap[key];
      if (actDef) {
        initMenuInPayload(actDef.menuId); 
        payloadMap[actDef.menuId].action.push({
          actionId: parseInt(key, 10), 
          actionLabel: actDef.label 
        });
      }
    }
  });

  return Object.values(payloadMap);
};

export const parsePayloadToFlatIds = (payload) => {
  const flatIds = new Set();
  if (!payload || !Array.isArray(payload)) return Array.from(flatIds);

  payload.forEach(menu => {
    if (menu.menuId) flatIds.add(`MENU|${menu.menuId}`);
    if (menu.action && Array.isArray(menu.action)) {
      menu.action.forEach(act => {
        if (act.actionId) flatIds.add(`ACTION|${act.actionId}`);
      });
    }
  });

  return Array.from(flatIds);
};