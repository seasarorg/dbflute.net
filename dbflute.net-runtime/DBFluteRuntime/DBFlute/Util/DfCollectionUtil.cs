/*
 * Copyright 2014-2015 the original author or authors.
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *     http://www.apache.org/licenses/LICENSE-2.0
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
 * either express or implied. See the License for the specific language
 * governing permissions and limitations under the License.
 */
using System;
using DBFlute.JavaLike;
using DBFlute.JavaLike.Extensions;
using DBFlute.JavaLike.Lang;
using DBFlute.JavaLike.Time;
using DBFlute.JavaLike.Util;
using boolean = System.Boolean;

namespace DBFlute.Util {

/**
 * @author jflute
 * @since 0.9.4 (2009/03/20 Friday)
 */
public class DfCollectionUtil {

    // ===================================================================================
    //                                                                          Definition
    //                                                                          ==========
    // Collections's empty collections can be called clear()
    // (unmodifiable used before 1.1)
    private static readonly List<object> EMPTY_LIST = Collections.emptyList<object>();
    private static readonly Map<object, object> EMPTY_MAP = Collections.emptyMap<object, object>();
    private static readonly Set<object> EMPTY_SET = Collections.emptySet<object>();

    // ===================================================================================
    //                                                                          Collection
    //                                                                          ==========
    public static Type findFirstElementType(Collection<object> collection) {
        foreach (Object obj in collection) {
            if (obj != null) {
                return obj.getClass();
            }
        }
        return null;
    }

    public static boolean hasValidElement(Collection<object> collection) {
        foreach (Object obj in collection) {
            if (obj != null) {
                return true;
            }
        }
        return false;
    }

    // ===================================================================================
    //                                                                                List
    //                                                                                ====
    public static ArrayList<ELEMENT> newArrayList<ELEMENT>() {
        return new ArrayList<ELEMENT>();
    }

    public static ArrayList<ELEMENT> newArrayList<ELEMENT>(System.Collections.Generic.ICollection<ELEMENT> elements) {
        ArrayList<ELEMENT> list = newArrayListSized<ELEMENT>(elements.size());
        list.addAll(elements);
        return list;
    }

    public static ArrayList<ELEMENT> newArrayList<ELEMENT>(params ELEMENT[] elements) {
        ArrayList<ELEMENT> list = newArrayListSized<ELEMENT>(elements.length());
        foreach (ELEMENT element in elements) {
            list.add(element);
        }
        return list;
    }

    public static ArrayList<ELEMENT> newArrayListSized<ELEMENT>(int size) {
        return new ArrayList<ELEMENT>(size);
    }

    public static List<ELEMENT> emptyList<ELEMENT>()
    {
        return (List<ELEMENT>) EMPTY_LIST;
    }

    // -----------------------------------------------------
    //                                               Utility
    //                                               -------
    public static List<List<ELEMENT>> splitByLimit<ELEMENT>(List<ELEMENT> elementList, int limit)
    {
        List<List<ELEMENT>> valueList = new ArrayList<List<ELEMENT>>();
        int valueSize = elementList.size();
        int index = 0;
        int remainderSize = valueSize;
        do {
            int beginIndex = limit * index;
            int endPoint = beginIndex + limit;
            int endIndex = limit <= remainderSize ? endPoint : valueSize;
            List<ELEMENT> splitList = newArrayList<ELEMENT>();
            splitList.addAll(elementList.subList(beginIndex, endIndex));
            valueList.add(splitList);
            remainderSize = valueSize - endIndex;
            ++index;
        } while (remainderSize > 0);
        return valueList;
    }

    // -----------------------------------------------------
    //                                               Advance
    //                                               -------
    public static OrderDiff<ELEMENT> analyzeOrderDiff<ELEMENT>(List<ELEMENT> beforeUniqueList, List<ELEMENT> afterUniqueList) where ELEMENT : class
    {
        LinkedHashSet<ELEMENT> linkedBeforeSet = newLinkedHashSet<ELEMENT>(beforeUniqueList);
        if (beforeUniqueList.size() != linkedBeforeSet.size()) {
            String msg = "The argument 'beforeList' should be unique: " + beforeUniqueList;
            throw new IllegalArgumentException(msg);
        }
        LinkedHashSet<ELEMENT> linkedAfterSet = newLinkedHashSet<ELEMENT>(afterUniqueList);
        if (afterUniqueList.size() != linkedAfterSet.size()) {
            String msg = "The argument 'afterList' should be unique: " + afterUniqueList;
            throw new IllegalArgumentException(msg);
        }
        ElementDiff<ELEMENT> elementDiff = analyzeElementDiff(linkedBeforeSet, linkedAfterSet);
        Set<ELEMENT> addedSet = elementDiff.getAddedSet();
        Set<ELEMENT> deletedSet = elementDiff.getDeletedSet();
        List<ELEMENT> beforeRemainingList = newArrayList<ELEMENT>(beforeUniqueList);
        beforeRemainingList.removeAll(deletedSet);
        List<ELEMENT> afterRemainingList = newArrayList<ELEMENT>(afterUniqueList);
        afterRemainingList.removeAll(addedSet);
        if (beforeRemainingList.size() != afterRemainingList.size()) {
            String msg = "The beforeRemainingList.size() should be the same as the afterRemainingList's:";
            msg = msg + " beforeRemainingList.size()=" + beforeRemainingList.size();
            msg = msg + " afterRemainingList.size()=" + afterRemainingList.size();
            throw new IllegalStateException(msg);
        }
        Map<ELEMENT, OrderDiffDetail<ELEMENT>> movedMap = newLinkedHashMap<ELEMENT, OrderDiffDetail<ELEMENT>>();
        doAnalyzeOrderChange(beforeRemainingList, afterRemainingList, movedMap);
        foreach (Entry<ELEMENT, OrderDiffDetail<ELEMENT>> entry in movedMap.entrySet()) {
            ELEMENT movedElement = entry.getKey();
            ELEMENT previousElement = entry.getValue().getPreviousElement();
            int movedIndex = afterUniqueList.indexOf(movedElement);
            ELEMENT realPrevious = afterUniqueList.get(movedIndex - 1);
            if (!previousElement.equals(realPrevious)) {
                entry.getValue().setPreviousElement(realPrevious);
            }
        }
        OrderDiff<ELEMENT> orderDiff = new OrderDiff<ELEMENT>();
        orderDiff.setMovedMap(movedMap);
        return orderDiff;
    }

    protected static void doAnalyzeOrderChange<ELEMENT>(List<ELEMENT> beforeRemainingList, List<ELEMENT> afterRemainingList,  Map<ELEMENT, OrderDiffDetail<ELEMENT>> movedMap) where ELEMENT : class {
        ELEMENT movedElement = null;
        ELEMENT previousElement = null;
        for (int i = 0; i < beforeRemainingList.size(); i++) {
            ELEMENT beforeElement = beforeRemainingList.get(i);
            int afterIndex = afterRemainingList.indexOf(beforeElement);
            if (i == afterIndex) { // no change
                continue;
            }
            // changed
            movedElement = beforeElement;
            previousElement = afterRemainingList.get(afterIndex - 1);
            break;
        }
        if (movedElement != null) {
            OrderDiffDetail<ELEMENT> diffResult = new OrderDiffDetail<ELEMENT>();
            diffResult.setMovedElement(movedElement);
            diffResult.setPreviousElement(previousElement);
            movedMap.put(movedElement, diffResult);
            List<ELEMENT> movedList = moveElementToIndex(beforeRemainingList, movedElement, previousElement);
            doAnalyzeOrderChange(movedList, afterRemainingList, movedMap); // recursive call
        }
    }

    public class OrderDiff<ELEMENT> {
        protected Map<ELEMENT, OrderDiffDetail<ELEMENT>> _movedMap;

        public Map<ELEMENT, OrderDiffDetail<ELEMENT>> getMovedMap() {
            return _movedMap;
        }

        public void setMovedMap(Map<ELEMENT, OrderDiffDetail<ELEMENT>> movedMap) {
            this._movedMap = movedMap;
        }
    }

    public class OrderDiffDetail<ELEMENT> {
        protected ELEMENT _movedElement;
        protected ELEMENT _previousElement;

        public ELEMENT getMovedElement() {
            return _movedElement;
        }

        public void setMovedElement(ELEMENT movedElement) {
            this._movedElement = movedElement;
        }

        public ELEMENT getPreviousElement() {
            return _previousElement;
        }

        public void setPreviousElement(ELEMENT previousElement) {
            this._previousElement = previousElement;
        }
    }

    public static List<ELEMENT> moveElementToIndex<ELEMENT>(List<ELEMENT> list, ELEMENT fromElement, ELEMENT toElement) {
        assertObjectNotNull("list", list);
        int fromIndex = list.indexOf(fromElement);
        int toIndex = list.indexOf(toElement);
        return moveElementToIndex(list, fromIndex, toIndex);
    }

    public static List<ELEMENT> moveElementToIndex<ELEMENT>(List<ELEMENT> list, int fromIndex, int toIndex) {
        assertObjectNotNull("list", list);
        if (fromIndex == toIndex) {
            String msg = "The argument 'fromIndex' and 'toIndex' should not be same:";
            msg = msg + " fromIndex=" + fromIndex + " toIndex" + toIndex;
            throw new IllegalArgumentException(msg);
        }
        if (fromIndex < 0 || toIndex < 0) {
            String msg = "The argument 'fromIndex' and 'toIndex' should not be minus:";
            msg = msg + " fromIndex=" + fromIndex + " toIndex" + toIndex;
            throw new IllegalArgumentException(msg);
        }
        boolean fromLess = fromIndex < toIndex;
        List<ELEMENT> movedList = new ArrayList<ELEMENT>();
        int firstIndex = fromLess ? fromIndex : toIndex;
        int secondIndex = !fromLess ? fromIndex : toIndex;
        List<ELEMENT> first = list.subList(0, firstIndex);
        ELEMENT element = list.get(fromIndex);
        int adjustmentIndex = fromLess ? 1 : 0;
        List<ELEMENT> middle = list.subList(firstIndex + adjustmentIndex, secondIndex + adjustmentIndex);
        List<ELEMENT> last = list.subList(secondIndex + 1, list.size());
        movedList.addAll(first);
        if (!fromLess) {
            movedList.add(element);
        }
        movedList.addAll(middle);
        if (fromLess) {
            movedList.add(element);
        }
        movedList.addAll(last);
        return movedList;
    }

    // ===================================================================================
    //                                                                                 Map
    //                                                                                 ===
    public static HashMap<KEY, VALUE> newHashMap<KEY, VALUE>() {
        return new HashMap<KEY, VALUE>();
    }

    public static HashMap<KEY, VALUE> newHashMap<KEY, VALUE>(Map<KEY, VALUE> map) {
        return new HashMap<KEY, VALUE>(map);
    }

    public static HashMap<KEY, VALUE> newHashMap<KEY, VALUE>(KEY key, VALUE value) {
        HashMap<KEY, VALUE> map = newHashMapSized<KEY, VALUE>(1);
        map.put(key, value);
        return map;
    }

    public static HashMap<KEY, VALUE> newHashMap<KEY, VALUE>(KEY key1, VALUE value1, KEY key2, VALUE value2) {
        HashMap<KEY, VALUE> map = newHashMapSized<KEY, VALUE>(2);
        map.put(key1, value1);
        map.put(key2, value2);
        return map;
    }

    public static HashMap<KEY, VALUE> newHashMapSized<KEY, VALUE>(int size) {
        return new HashMap<KEY, VALUE>(size);
    }

    public static LinkedHashMap<KEY, VALUE> newLinkedHashMap<KEY, VALUE>() {
        return new LinkedHashMap<KEY, VALUE>();
    }

    public static LinkedHashMap<KEY, VALUE> newLinkedHashMap<KEY, VALUE>(Map<KEY, VALUE> map) {
        return new LinkedHashMap<KEY, VALUE>(map);
    }

    public static LinkedHashMap<KEY, VALUE> newLinkedHashMap<KEY, VALUE>(KEY key, VALUE value) {
        LinkedHashMap<KEY, VALUE> map = newLinkedHashMapSized<KEY, VALUE>(1);
        map.put(key, value);
        return map;
    }

    public static LinkedHashMap<KEY, VALUE> newLinkedHashMap<KEY, VALUE>(KEY key1, VALUE value1, KEY key2, VALUE value2) {
        LinkedHashMap<KEY, VALUE> map = newLinkedHashMapSized<KEY, VALUE>(2);
        map.put(key1, value1);
        map.put(key2, value2);
        return map;
    }

    public static LinkedHashMap<KEY, VALUE> newLinkedHashMapSized<KEY, VALUE>(int size) {
        return new LinkedHashMap<KEY, VALUE>(size);
    }

    public static ConcurrentHashMap<KEY, VALUE> newConcurrentHashMap<KEY, VALUE>() {
        return new ConcurrentHashMap<KEY, VALUE>();
    }

    public static ConcurrentHashMap<KEY, VALUE> newConcurrentHashMap<KEY, VALUE>(Map<KEY, VALUE> map) {
        return new ConcurrentHashMap<KEY, VALUE>(map);
    }

    public static ConcurrentHashMap<KEY, VALUE> newConcurrentHashMap<KEY, VALUE>(KEY key, VALUE value) {
        ConcurrentHashMap<KEY, VALUE> map = newConcurrentHashMapSized<KEY, VALUE>(1);
        map.put(key, value);
        return map;
    }

    public static ConcurrentHashMap<KEY, VALUE> newConcurrentHashMap<KEY, VALUE>(KEY key1, VALUE value1, KEY key2, VALUE value2) {
        ConcurrentHashMap<KEY, VALUE> map = newConcurrentHashMapSized<KEY, VALUE>(2);
        map.put(key1, value1);
        map.put(key2, value2);
        return map;
    }

    public static ConcurrentHashMap<KEY, VALUE> newConcurrentHashMapSized<KEY, VALUE>(int size) {
        return new ConcurrentHashMap<KEY, VALUE>(size);
    }

    
    public static Map<KEY, VALUE> emptyMap<KEY, VALUE>() {
        return (Map<KEY, VALUE>) EMPTY_MAP;
    }

    // ===================================================================================
    //                                                                                 Set
    //                                                                                 ===
    public static HashSet<ELEMENT> newHashSet<ELEMENT>() {
        return new HashSet<ELEMENT>();
    }

    public static HashSet<ELEMENT> newHashSet<ELEMENT>(Collection<ELEMENT> elements)
    {
        HashSet<ELEMENT> set = newHashSetSized<ELEMENT>(elements.size());
        set.addAll(elements);
        return set;
    }

    
    public static HashSet<ELEMENT> newHashSet<ELEMENT>(params ELEMENT[] elements) {
        HashSet<ELEMENT> set = newHashSetSized<ELEMENT>(elements.length());
        foreach (ELEMENT element in elements) {
            set.add(element);
        }
        return set;
    }

    public static HashSet<ELEMENT> newHashSetSized<ELEMENT>(int size) {
        return new HashSet<ELEMENT>(size);
    }

    public static LinkedHashSet<ELEMENT> newLinkedHashSet<ELEMENT>() {
        return new LinkedHashSet<ELEMENT>();
    }

    public static LinkedHashSet<ELEMENT> newLinkedHashSet<ELEMENT>(System.Collections.Generic.ICollection<ELEMENT> elements) {
        LinkedHashSet<ELEMENT> set = newLinkedHashSetSized<ELEMENT>(elements.size());
        set.addAll(elements);
        return set;
    }

    
    public static LinkedHashSet<ELEMENT> newLinkedHashSet<ELEMENT>(params ELEMENT[] elements) {
        LinkedHashSet<ELEMENT> set = newLinkedHashSetSized<ELEMENT>(elements.length());
        foreach (ELEMENT element in elements) {
            set.add(element);
        }
        return set;
    }

    public static LinkedHashSet<ELEMENT> newLinkedHashSetSized<ELEMENT>(int size) {
        return new LinkedHashSet<ELEMENT>(size);
    }

    
    public static Set<ELEMENT> emptySet<ELEMENT>() {
        return (Set<ELEMENT>) EMPTY_SET;
    }

    // -----------------------------------------------------
    //                                               Advance
    //                                               -------
    public static ElementDiff<ELEMENT> analyzeElementDiff<ELEMENT>(Set<ELEMENT> beforeCol, Set<ELEMENT> afterCol) {
        Set<ELEMENT> addedSet = newLinkedHashSet<ELEMENT>();
        Set<ELEMENT> deletedSet = newLinkedHashSet<ELEMENT>();
        Set<ELEMENT> remainingSet = newLinkedHashSet<ELEMENT>();
        foreach (ELEMENT beforeElement in beforeCol) {
            if (afterCol.contains(beforeElement)) {
                remainingSet.add(beforeElement);
            } else {
                deletedSet.add(beforeElement);
            }
        }
        foreach (ELEMENT afterElement in afterCol) {
            if (!beforeCol.contains(afterElement)) {
                addedSet.add(afterElement);
            }
        }
        ElementDiff<ELEMENT> elementDiff = new ElementDiff<ELEMENT>();
        elementDiff.setAddedSet(addedSet);
        elementDiff.setDeletedSet(deletedSet);
        elementDiff.setRemainingSet(remainingSet);
        return elementDiff;
    }

    public class ElementDiff<ELEMENT> {
        protected Set<ELEMENT> _addedSet;
        protected Set<ELEMENT> _deletedSet;
        protected Set<ELEMENT> _remainingSet;

        public Set<ELEMENT> getAddedSet() {
            return _addedSet;
        }

        public void setAddedSet(Set<ELEMENT> addedSet) {
            this._addedSet = addedSet;
        }

        public Set<ELEMENT> getDeletedSet() {
            return _deletedSet;
        }

        public void setDeletedSet(Set<ELEMENT> deletedSet) {
            this._deletedSet = deletedSet;
        }

        public Set<ELEMENT> getRemainingSet() {
            return _remainingSet;
        }

        public void setRemainingSet(Set<ELEMENT> remainingSet) {
            this._remainingSet = remainingSet;
        }
    }

    // ===================================================================================
    //                                                                               Order
    //                                                                               =====
    /**
     * Order the unordered list according to specified resources.
     * @param <ELEMENT_TYPE> The type of element.
     * @param <ID_TYPE> The type of ID.
     * @param unorderedList The unordered list. (NotNull)
     * @param resource The resource of according-to-order. (NotNull)
     */
    public static void orderAccordingTo<ELEMENT_TYPE, ID_TYPE>(List<ELEMENT_TYPE> unorderedList, AccordingToOrderResource<ELEMENT_TYPE, ID_TYPE> resource) {
        assertObjectNotNull("unorderedList", unorderedList);
        if (unorderedList.isEmpty()) {
            return;
        }
        assertObjectNotNull("resource", resource);
        List<ID_TYPE> orderedUniqueIdList = resource.getOrderedUniqueIdList();
        assertObjectNotNull("resource.getOrderedUniqueIdList()", orderedUniqueIdList);
        if (orderedUniqueIdList.isEmpty()) {
            return;
        }
        AccordingToOrderIdExtractor<ELEMENT_TYPE, ID_TYPE> idExtractor = resource.getIdExtractor();
        assertObjectNotNull("resource.getIdExtractor()", idExtractor);

        Map<ID_TYPE, Integer> idIndexMap = new LinkedHashMap<ID_TYPE, Integer>();
        int index = 0;
        foreach (ID_TYPE id in orderedUniqueIdList) {
            if (idIndexMap.containsKey(id)) {
                String msg = "The id was duplicated: id=" + id + " orderedUniqueIdList=" + orderedUniqueIdList;
                throw new IllegalStateException(msg);
            }
            idIndexMap.put(id, index);
            ++index;
        }

        Comparater<ELEMENT_TYPE> comp = ((o1, o2) => {
            ID_TYPE id1 = idExtractor.extractId(o1);
            ID_TYPE id2 = idExtractor.extractId(o2);
            assertObjectNotNull("id1 of " + o1, id1);
            assertObjectNotNull("id2 of " + o2, id2);
            Integer index1 = idIndexMap.get(id1);
            Integer index2 = idIndexMap.get(id2);
            if (index1 != null && index2 != null) {
                return index1.compareTo(index2);
            }
            if (index1 == null && index2 == null) {
                return 0;
            }
            return index1 == null ? 1 : -1;
        });
        Collections.sort(unorderedList, comp);
    }

    public interface AccordingToOrderIdExtractor<ELEMENT_TYPE, ID_TYPE> {

        /**
         * Extract ID from the element instance.
         * @param element Element instance. (NotNull)
         * @return Extracted ID. (NotNull)
         */
        ID_TYPE extractId(ELEMENT_TYPE element);
    }

    public class AccordingToOrderResource<ELEMENT_TYPE, ID_TYPE> {
        protected List<ID_TYPE> _orderedUniqueIdList;
        protected AccordingToOrderIdExtractor<ELEMENT_TYPE, ID_TYPE> _idExtractor;

        public AccordingToOrderResource<ELEMENT_TYPE, ID_TYPE> setupResource(List<ID_TYPE> orderedUniqueIdList,
                AccordingToOrderIdExtractor<ELEMENT_TYPE, ID_TYPE> idExtractor) {
            setOrderedUniqueIdList(orderedUniqueIdList);
            setIdExtractor(idExtractor);
            return this;
        }

        public List<ID_TYPE> getOrderedUniqueIdList()
        {
            return _orderedUniqueIdList;
        }

        public void setOrderedUniqueIdList(List<ID_TYPE> orderedUniqueIdList)
        {
            _orderedUniqueIdList = orderedUniqueIdList;
        }

        public AccordingToOrderIdExtractor<ELEMENT_TYPE, ID_TYPE> getIdExtractor() {
            return _idExtractor;
        }

        public void setIdExtractor(AccordingToOrderIdExtractor<ELEMENT_TYPE, ID_TYPE> idExtractor) {
            _idExtractor = idExtractor;
        }
    }

    // ===================================================================================
    //                                                                       Assert Helper
    //                                                                       =============
    protected static void assertObjectNotNull(String variableName, Object value) {
        if (variableName == null) {
            String msg = "The value should not be null: variableName=null value=" + value;
            throw new IllegalArgumentException(msg);
        }
        if (value == null) {
            String msg = "The value should not be null: variableName=" + variableName;
            throw new IllegalArgumentException(msg);
        }
    }
}

}